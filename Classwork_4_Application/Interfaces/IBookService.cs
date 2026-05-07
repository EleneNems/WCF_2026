using Classwork_4_Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.Interfaces
{
    public interface IBookService
    {
        Task<List<BooksDTO>> GetBooksAsync(GetBooksDTO filter);
        Task<BooksDTO?> GetBookByIdAsync(int id);
        Task<string> AddBookAsync(CreateBookDTO dto);
        Task<string> UpdateBookAsync(UpdateBookDTO dto);
        Task<string> DeleteBookAsync(int id);
    }
}
