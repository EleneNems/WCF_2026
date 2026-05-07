using Classwork_4_Application.DTOs;
using Classwork_4_Application.Interfaces;
using Classwork_4_Application.Interfaces.Repositories;
using Classwork_4_Domain.Entity;

namespace Classwork_4_Application.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _loanRepository;

    public LoanService(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
    }

    public async Task<List<LoansDTO>> GetLoansAsync()
    {
        var loans = await _loanRepository.GetLoansAsync();

        return loans.Select(l => new LoansDTO
        {
            Id = l.Id,
            ReaderId = l.ReaderId,
            ReaderName = l.Reader.FirstName + " " + l.Reader.LastName,
            BookId = l.BookId,
            BookTitle = l.Book.Title,
            LoanDate = l.LoanDate,
            DueDate = l.DueDate,
            ReturnDate = l.ReturnDate,
            ReturnCondition = l.ReturnCondition,
            IsReturned = l.IsReturned,
            FineAmount = l.FineAmount
        }).ToList();
    }

    public async Task<string> IssueBookAsync(IssueBookDTO dto)
    {
        var reader = await _loanRepository.GetReaderByIdAsync(dto.ReaderId);

        if (reader == null)
            return "Reader not found.";

        if (reader.Status == ReaderStatus.Blocked)
            return "Blocked reader cannot borrow books.";

        if (reader.Status == ReaderStatus.Cancelled)
            return "Cancelled reader cannot borrow books.";

        var book = await _loanRepository.GetBookByIdAsync(dto.BookId);

        if (book == null)
            return "Book not found.";

        if (book.AvailableQuantity <= 0)
            return "Book is not available.";

        int activeLoansCount =
            await _loanRepository.GetActiveLoansCountAsync(dto.ReaderId);

        if (activeLoansCount >= 3)
            return "Reader already has 3 unreturned books.";

        if (dto.DueDate > dto.LoanDate.AddDays(14))
            return "Due date cannot be more than 14 days after loan date.";

        if (dto.DueDate < dto.LoanDate)
            return "Due date cannot be before loan date.";

        var loan = new Loan
        {
            ReaderId = dto.ReaderId,
            BookId = dto.BookId,
            LoanDate = dto.LoanDate,
            DueDate = dto.DueDate,
            IsReturned = false,
            FineAmount = 0
        };

        book.AvailableQuantity--;

        await _loanRepository.AddLoanAsync(loan);
        await _loanRepository.SaveChangesAsync();

        return "Book issued successfully.";
    }

    public async Task<string> ReturnBookAsync(ReturnBookDTO dto)
    {
        var loan = await _loanRepository.GetLoanByIdAsync(dto.LoanId);

        if (loan == null)
            return "Loan not found.";

        if (loan.IsReturned)
            return "Book is already returned.";

        if (dto.ReturnDate < loan.LoanDate)
            return "Return date cannot be before loan date.";

        loan.ReturnDate = dto.ReturnDate;
        loan.ReturnCondition = dto.Condition;
        loan.IsReturned = true;

        loan.FineAmount =
            CalculateFine(loan.DueDate, dto.ReturnDate);

        if (dto.Condition == ReturnCondition.Good)
        {
            loan.Book.AvailableQuantity++;
        }
        else if (dto.Condition == ReturnCondition.Lost)
        {
            loan.Book.TotalQuantity--;

            if (loan.Book.TotalQuantity < 0)
                loan.Book.TotalQuantity = 0;

            if (loan.Book.AvailableQuantity > loan.Book.TotalQuantity)
                loan.Book.AvailableQuantity = loan.Book.TotalQuantity;
        }

        await _loanRepository.SaveChangesAsync();

        await CheckAndBlockReaderAsync(loan.ReaderId);

        return $"Book returned. Fine: {loan.FineAmount} GEL.";
    }

    private decimal CalculateFine(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate.Date <= dueDate.Date)
            return 0;

        int lateDays = (returnDate.Date - dueDate.Date).Days;

        return lateDays * 1;
    }

    private async Task CheckAndBlockReaderAsync(int readerId)
    {
        var reader = await _loanRepository.GetReaderByIdAsync(readerId);

        if (reader == null)
            return;

        decimal totalFine =
            await _loanRepository.GetTotalFineAsync(readerId);

        int lostBooksCount =
            await _loanRepository.GetLostBooksCountAsync(readerId);

        int overdueUnreturnedCount =
            await _loanRepository.GetOverdueUnreturnedCountAsync(readerId);

        if (totalFine > 20 ||
            lostBooksCount >= 2 ||
            overdueUnreturnedCount > 3)
        {
            reader.Status = ReaderStatus.Blocked;

            await _loanRepository.SaveChangesAsync();
        }
    }
}