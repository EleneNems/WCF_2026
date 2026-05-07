using Classwork_4_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        Task<List<Loan>> GetLoansAsync();

        Task<Loan?> GetLoanByIdAsync(int id);

        Task<Reader?> GetReaderByIdAsync(int readerId);

        Task<Book?> GetBookByIdAsync(int bookId);

        Task<int> GetActiveLoansCountAsync(int readerId);

        Task<decimal> GetTotalFineAsync(int readerId);

        Task<int> GetLostBooksCountAsync(int readerId);

        Task<int> GetOverdueUnreturnedCountAsync(int readerId);

        Task AddLoanAsync(Loan loan);

        Task SaveChangesAsync();
    }
}
