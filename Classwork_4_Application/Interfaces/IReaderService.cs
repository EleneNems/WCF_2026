using Classwork_4_Application.DTOs;
using Classwork_4_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.Interfaces
{
    public interface IReaderService
    {
        Task<List<ReadersDTO>> GetReadersAsync(GetReadersDTO filter);
        Task<ReadersDTO?> GetReaderByIdAsync(int id);
        Task<string> AddReaderAsync(CreateReaderDTO dto);
        Task<string> UpdateReaderAsync(UpdateReaderDTO dto);
        Task<string> DeleteReaderAsync(int id);
    }
}
