using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Classwork_4_Infrastructure.Services;

public class LoanService
{
    private readonly LibraryDbContext _context;

    public LoanService(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<List<Loan>> GetLoansAsync()
    {
        return await _context.Loans.Include(l => l.Book).Include(l => l.Reader).ToListAsync();
    }

    public async Task<string> IssueBookAsync(int readerId, int bookId, DateTime loanDate, DateTime dueDate)
    {
        var reader = await _context.Readers.FindAsync(readerId);
        if (reader == null)
        {
            return "Reader not found.";
        }

        if (reader.Status == ReaderStatus.Blocked)
        {
            return "Blocked reader cannot borrow books.";
        }
            
        if (reader.Status == ReaderStatus.Cancelled)
        {
            return "Cancelled reader cannot borrow books.";
        }
            

        var book = await _context.Books.FindAsync(bookId);
        if (book == null)
        {
            return "Book not found.";
        }
            
        if (book.AvailableQuantity <= 0)
        {
            return "Book is not available.";
        }
            
        int activeLoansCount = await _context.Loans.CountAsync(l => l.ReaderId == readerId && !l.IsReturned);

        if (activeLoansCount >= 3)
        {
            return "Reader already has 3 unreturned books.";
        }
            

        if (dueDate > loanDate.AddDays(14))
        {
            return "Due date cannot be more than 14 days after loan date.";
        }
            

        var loan = new Loan
        {
            ReaderId = readerId,
            BookId = bookId,
            LoanDate = loanDate,
            DueDate = dueDate,
            IsReturned = false,
            FineAmount = 0
        };

        book.AvailableQuantity--;

        _context.Loans.Add(loan);
        await _context.SaveChangesAsync();

        return "Book issued successfully.";
    }

    public async Task<string> ReturnBookAsync(int loanId, DateTime returnDate, ReturnCondition condition)
    {
        var loan = await _context.Loans.Include(l => l.Book).Include(l => l.Reader).FirstOrDefaultAsync(l => l.Id == loanId);

        if (loan == null)
        {
            return "Loan not found.";
        }

        if (loan.IsReturned) {
            return "Book is already returned.";
        }

        loan.ReturnDate = returnDate;
        loan.ReturnCondition = condition;
        loan.IsReturned = true;


        loan.FineAmount = CalculateFine(loan.DueDate, returnDate);

        if (condition == ReturnCondition.Good)
        {
            loan.Book.AvailableQuantity++;
        }
        else if (condition == ReturnCondition.Damaged)
        { 

        }
        else if (condition == ReturnCondition.Lost)
        {
            loan.Book.TotalQuantity--;

            if (loan.Book.AvailableQuantity > loan.Book.TotalQuantity)
            {
                loan.Book.AvailableQuantity = loan.Book.TotalQuantity;
            }
                
        }

        await _context.SaveChangesAsync();

        await CheckAndBlockReaderAsync(loan.ReaderId);

        return $"Book returned. Fine: {loan.FineAmount} GEL.";
    }

    public decimal CalculateFine(DateTime dueDate, DateTime returnDate)
    {
        if (returnDate <= dueDate)
        {
            return 0;
        }
            

        int lateDays = (returnDate.Date - dueDate.Date).Days;

        return lateDays * 1;
    }

    public async Task CheckAndBlockReaderAsync(int readerId)
    {
        var reader = await _context.Readers.FindAsync(readerId);

        if (reader == null)
        {
            return;
        }
            

        decimal totalFine = await _context.Loans.Where(l => l.ReaderId == readerId).SumAsync(l => l.FineAmount);

        int lostBooksCount = await _context.Loans.CountAsync(l => l.ReaderId == readerId && l.ReturnCondition == ReturnCondition.Lost);

        int overdueUnreturnedCount = await _context.Loans.CountAsync(l => l.ReaderId == readerId && !l.IsReturned && l.DueDate < DateTime.Now);

        if (totalFine > 20 || lostBooksCount >= 2 || overdueUnreturnedCount > 3)
        {
            reader.Status = ReaderStatus.Blocked;
            await _context.SaveChangesAsync();
        }
    }
}