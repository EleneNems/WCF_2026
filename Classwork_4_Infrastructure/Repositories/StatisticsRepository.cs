using Classwork_4_Application.Interfaces.Repositories;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Classwork_4_Infrastructure.Repositories;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly LibraryDbContext _context;

    public StatisticsRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<int> GetTotalBooksQuantityAsync()
    {
        return await _context.Books.SumAsync(b => b.TotalQuantity);
    }

    public async Task<int> GetAvailableBooksQuantityAsync()
    {
        return await _context.Books.SumAsync(b => b.AvailableQuantity);
    }

    public async Task<int> GetIssuedBooksCountAsync()
    {
        return await _context.Loans.CountAsync(l => !l.IsReturned);
    }

    public async Task<int> GetLateReturnsCountAsync()
    {
        return await _context.Loans
            .CountAsync(l => l.IsReturned && l.ReturnDate > l.DueDate);
    }

    public async Task<int> GetBlockedReadersCountAsync()
    {
        return await _context.Readers
            .CountAsync(r => r.Status == ReaderStatus.Blocked);
    }

    public async Task<object?> GetMostIssuedBookAsync()
    {
        return await _context.Loans
            .GroupBy(l => new
            {
                l.BookId,
                l.Book.Title
            })
            .Select(g => new
            {
                BookId = g.Key.BookId,
                BookTitle = g.Key.Title,
                IssueCount = g.Count()
            })
            .OrderByDescending(x => x.IssueCount)
            .FirstOrDefaultAsync();
    }

    public async Task<object?> GetMostActiveReaderAsync()
    {
        return await _context.Loans
            .GroupBy(l => new
            {
                l.ReaderId,
                l.Reader.FirstName,
                l.Reader.LastName
            })
            .Select(g => new
            {
                ReaderId = g.Key.ReaderId,
                ReaderName = g.Key.FirstName + " " + g.Key.LastName,
                LoanCount = g.Count()
            })
            .OrderByDescending(x => x.LoanCount)
            .FirstOrDefaultAsync();
    }
}