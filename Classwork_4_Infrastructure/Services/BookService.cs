using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork_4_Domain;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Classwork_4_Infrastructure.Services
{
    public class BookService
    {

        private readonly LibraryDbContext _libraryDbContext;

        public BookService(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<List<Book>> GetBooksAsync(string? title, string? author, string? category, string? isbn)
        {
            var query = _libraryDbContext.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(b => b.Author.Contains(author));
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(b => b.Category.Contains(category));
            }

            if (!string.IsNullOrWhiteSpace(isbn))
            {
                query = query.Where(b => b.ISBN.Contains(isbn));
            }

            return await query.ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _libraryDbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<string> AddBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                return "Book title is required.";
            }
                
            bool isbnExists = await _libraryDbContext.Books.AnyAsync(b => b.ISBN == book.ISBN);
            if (isbnExists)
            {
                return "ISBN must be unique.";
            }
                

            if (book.PublishYear > DateTime.Now.Year)
            {
                return "Publish year cannot be greater than current year.";
            }

            if (book.TotalQuantity < 1)
            {
                return "Total quantity must be at least 1.";
            }
                
            if (book.AvailableQuantity > book.TotalQuantity)
            {
                return "Available quantity cannot be greater than total quantity.";
            }

            _libraryDbContext.Books.Add(book);
            await _libraryDbContext.SaveChangesAsync();

            return "Book added successfully.";
        }

        public async Task<string> UpdateBookAsync(Book book)
        {
            var existingBook = await _libraryDbContext.Books
                .FirstOrDefaultAsync(b => b.Id == book.Id);

            if (existingBook == null)
            {
                return "Book not found.";
            }
                

            if (string.IsNullOrWhiteSpace(book.Title))
            {
                return "Book title is required.";
            }
                

            bool isbnExists = await _libraryDbContext.Books.AnyAsync(b => b.ISBN == book.ISBN && b.Id != book.Id);

            if (isbnExists)
            {
                return "ISBN must be unique.";
            }
                

            if (book.PublishYear > DateTime.Now.Year)
            {
                return "Publish year cannot be greater than current year.";
            }
                

            if (book.TotalQuantity < 1)
            {
                return "Total quantity must be at least 1.";
            }
                

            if (book.AvailableQuantity > book.TotalQuantity)
            {
                return "Available quantity cannot be greater than total quantity.";
            }
                

            existingBook.Title = book.Title;
            existingBook.ISBN = book.ISBN;
            existingBook.PublishYear = book.PublishYear;
            existingBook.Category = book.Category;
            existingBook.Author = book.Author;
            existingBook.TotalQuantity = book.TotalQuantity;
            existingBook.AvailableQuantity = book.AvailableQuantity;

            await _libraryDbContext.SaveChangesAsync();

            return "Book updated successfully.";
        }

        public async Task<string> DeleteBookAsync(int id)
        {
            var book = await _libraryDbContext.Books
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return "Book not found.";
            }
                

            _libraryDbContext.Books.Remove(book);

            await _libraryDbContext.SaveChangesAsync();

            return "Book deleted successfully.";
        }
    }
}
