using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Classwork_4_Infrastructure.Services;

public class StatisticsService
{
    private readonly LibraryDbContext _context;

    public StatisticsService(LibraryDbContext context)
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
            .CountAsync(r => r.Status == Classwork_4_Domain.Entity.ReaderStatus.Blocked);
    }

    public async Task<object?> GetMostIssuedBookAsync()
    {
        return await _context.Loans
            .GroupBy(l => l.Book)
            .Select(g => new
            {
                BookTitle = g.Key.Title,
                IssueCount = g.Count()
            })
            .OrderByDescending(x => x.IssueCount)
            .FirstOrDefaultAsync();
    }

    public async Task<object?> GetMostActiveReaderAsync()
    {
        return await _context.Loans
            .GroupBy(l => l.Reader)
            .Select(g => new
            {
                ReaderName = g.Key.FirstName + " " + g.Key.LastName,
                LoanCount = g.Count()
            })
            .OrderByDescending(x => x.LoanCount)
            .FirstOrDefaultAsync();
    }
}