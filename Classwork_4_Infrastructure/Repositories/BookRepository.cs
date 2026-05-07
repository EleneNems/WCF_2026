using Classwork_4_Application.Interfaces.Repositories;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Classwork_4_Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> IsbnExistsAsync(string isbn, int? currentBookId = null)
        {
            return await _context.Books
                .AnyAsync(b => b.ISBN == isbn && b.Id != currentBookId);
        }

        public async Task<bool> HasLoansAsync(int bookId)
        {
            return await _context.Loans
                .AnyAsync(l => l.BookId == bookId);
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _context.Categories
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<bool> AuthorExistsAsync(int authorId)
        {
            return await _context.Authors
                .AnyAsync(a => a.Id == authorId);
        }

        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

