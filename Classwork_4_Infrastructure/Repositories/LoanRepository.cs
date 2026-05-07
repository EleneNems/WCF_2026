using Classwork_4_Application.Interfaces.Repositories;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _context;

        public LoanRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Loan>> GetLoansAsync()
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .ToListAsync();
        }

        public async Task<Loan?> GetLoanByIdAsync(int id)
        {
            return await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Reader?> GetReaderByIdAsync(int readerId)
        {
            return await _context.Readers
                .FirstOrDefaultAsync(r => r.Id == readerId);
        }

        public async Task<Book?> GetBookByIdAsync(int bookId)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<int> GetActiveLoansCountAsync(int readerId)
        {
            return await _context.Loans
                .CountAsync(l => l.ReaderId == readerId && !l.IsReturned);
        }

        public async Task<decimal> GetTotalFineAsync(int readerId)
        {
            return await _context.Loans
                .Where(l => l.ReaderId == readerId)
                .SumAsync(l => l.FineAmount);
        }

        public async Task<int> GetLostBooksCountAsync(int readerId)
        {
            return await _context.Loans
                .CountAsync(l => l.ReaderId == readerId &&
                                 l.ReturnCondition == ReturnCondition.Lost);
        }

        public async Task<int> GetOverdueUnreturnedCountAsync(int readerId)
        {
            return await _context.Loans
                .CountAsync(l => l.ReaderId == readerId &&
                                 !l.IsReturned &&
                                 l.DueDate < DateTime.Now);
        }

        public async Task AddLoanAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
