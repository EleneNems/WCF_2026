using Classwork_4_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.Interfaces.Repositories
{
    public interface IReaderRepository
    {
        Task<List<Reader>> GetReadersAsync();

        Task<Reader?> GetReaderByIdAsync(int id);

        Task<bool> PersonalNumberExistsAsync(string personalNumber, int? currentReaderId = null);

        Task<bool> HasLoansAsync(int readerId);

        Task AddReaderAsync(Reader reader);

        void DeleteReader(Reader reader);

        Task SaveChangesAsync();
    }
}
