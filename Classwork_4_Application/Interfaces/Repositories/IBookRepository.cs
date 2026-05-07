using Classwork_4_Domain.Entity;

namespace Classwork_4_Application.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);

        Task<bool> IsbnExistsAsync(string isbn, int? currentBookId = null);
        Task<bool> HasLoansAsync(int bookId);
        Task<bool> CategoryExistsAsync(int categoryId);
        Task<bool> AuthorExistsAsync(int authorId);

        Task AddBookAsync(Book book);
        void DeleteBook(Book book);

        Task SaveChangesAsync();
    }
}

