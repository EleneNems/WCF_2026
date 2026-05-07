using Classwork_4_Application.DTOs;
using Classwork_4_Application.Interfaces;
using Classwork_4_Application.Interfaces.Repositories;
using Classwork_4_Domain.Entity;

namespace Classwork_4_Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BooksDTO>> GetBooksAsync(GetBooksDTO filter)
    {
        var books = await _bookRepository.GetBooksAsync();

        var query = books.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Title))
            query = query.Where(b => b.Title.Contains(filter.Title, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(filter.ISBN))
            query = query.Where(b => b.ISBN.Contains(filter.ISBN, StringComparison.OrdinalIgnoreCase));

        if (filter.AuthorId.HasValue)
            query = query.Where(b => b.AuthorId == filter.AuthorId.Value);

        if (filter.CategoryId.HasValue)
            query = query.Where(b => b.CategoryId == filter.CategoryId.Value);

        if (!string.IsNullOrWhiteSpace(filter.AuthorName))
            query = query.Where(b => b.Author.FullName.Contains(filter.AuthorName, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(filter.CategoryName))
            query = query.Where(b => b.Category.Name.Contains(filter.CategoryName, StringComparison.OrdinalIgnoreCase));

        return query.Select(b => new BooksDTO
        {
            Id = b.Id,
            Title = b.Title,
            ISBN = b.ISBN,
            PublishYear = b.PublishYear,
            AuthorId = b.AuthorId,
            AuthorName = b.Author.FullName,
            CategoryId = b.CategoryId,
            CategoryName = b.Category.Name,
            TotalQuantity = b.TotalQuantity,
            AvailableQuantity = b.AvailableQuantity
        }).ToList();
    }

    public async Task<BooksDTO?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);

        if (book == null)
            return null;

        return new BooksDTO
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            PublishYear = book.PublishYear,
            AuthorId = book.AuthorId,
            AuthorName = book.Author.FullName,
            CategoryId = book.CategoryId,
            CategoryName = book.Category.Name,
            TotalQuantity = book.TotalQuantity,
            AvailableQuantity = book.AvailableQuantity
        };
    }

    public async Task<string> AddBookAsync(CreateBookDTO dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            ISBN = dto.ISBN,
            PublishYear = dto.PublishYear,
            AuthorId = dto.AuthorId,
            CategoryId = dto.CategoryId,
            TotalQuantity = dto.TotalQuantity,
            AvailableQuantity = dto.AvailableQuantity
        };

        var validationResult = await ValidateBookAsync(book);

        if (validationResult != "Valid")
            return validationResult;

        await _bookRepository.AddBookAsync(book);
        await _bookRepository.SaveChangesAsync();

        return "Book added successfully.";
    }

    public async Task<string> UpdateBookAsync(UpdateBookDTO dto)
    {
        var existingBook = await _bookRepository.GetBookByIdAsync(dto.Id);

        if (existingBook == null)
            return "Book not found.";

        var bookForValidation = new Book
        {
            Id = dto.Id,
            Title = dto.Title,
            ISBN = dto.ISBN,
            PublishYear = dto.PublishYear,
            AuthorId = dto.AuthorId,
            CategoryId = dto.CategoryId,
            TotalQuantity = dto.TotalQuantity,
            AvailableQuantity = dto.AvailableQuantity
        };

        var validationResult = await ValidateBookAsync(bookForValidation, dto.Id);

        if (validationResult != "Valid")
            return validationResult;

        existingBook.Title = dto.Title;
        existingBook.ISBN = dto.ISBN;
        existingBook.PublishYear = dto.PublishYear;
        existingBook.AuthorId = dto.AuthorId;
        existingBook.CategoryId = dto.CategoryId;
        existingBook.TotalQuantity = dto.TotalQuantity;
        existingBook.AvailableQuantity = dto.AvailableQuantity;

        await _bookRepository.SaveChangesAsync();

        return "Book updated successfully.";
    }

    public async Task<string> DeleteBookAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);

        if (book == null)
            return "Book not found.";

        bool hasLoans = await _bookRepository.HasLoansAsync(id);

        if (hasLoans)
            return "Cannot delete this book because it has loan history.";

        _bookRepository.DeleteBook(book);
        await _bookRepository.SaveChangesAsync();

        return "Book deleted successfully.";
    }

    private async Task<string> ValidateBookAsync(Book book, int? currentBookId = null)
    {
        if (string.IsNullOrWhiteSpace(book.Title))
            return "Book title is required.";

        if (string.IsNullOrWhiteSpace(book.ISBN))
            return "ISBN is required.";

        bool isbnExists = await _bookRepository.IsbnExistsAsync(book.ISBN, currentBookId);

        if (isbnExists)
            return "ISBN must be unique.";

        if (book.PublishYear > DateTime.Now.Year)
            return "Publish year cannot be greater than current year.";

        if (book.TotalQuantity < 1)
            return "Total quantity must be at least 1.";

        if (book.AvailableQuantity < 0)
            return "Available quantity cannot be negative.";

        if (book.AvailableQuantity > book.TotalQuantity)
            return "Available quantity cannot be greater than total quantity.";

        bool categoryExists = await _bookRepository.CategoryExistsAsync(book.CategoryId);

        if (!categoryExists)
            return "Category does not exist.";

        bool authorExists = await _bookRepository.AuthorExistsAsync(book.AuthorId);

        if (!authorExists)
            return "Author does not exist.";

        return "Valid";
    }
}