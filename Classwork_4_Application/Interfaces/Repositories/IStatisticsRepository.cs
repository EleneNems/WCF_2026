using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.Interfaces.Repositories
{
    public interface IStatisticsRepository
    {
        Task<int> GetTotalBooksQuantityAsync();
        Task<int> GetAvailableBooksQuantityAsync();
        Task<int> GetIssuedBooksCountAsync();
        Task<int> GetLateReturnsCountAsync();
        Task<int> GetBlockedReadersCountAsync();

        Task<object?> GetMostIssuedBookAsync();
        Task<object?> GetMostActiveReaderAsync();
    }
}
