using Microsoft.AspNetCore.Mvc;
using Classwork_4_Application.DTOs;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Classwork_4_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks(
        [FromQuery] string? title,
        [FromQuery] string? author,
        [FromQuery] string? category,
        [FromQuery] string? isbn)
    {
        var books = await _bookService.GetBooksAsync(title, author, category, isbn);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
            return NotFound("Book not found.");

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(CreateBookDTO dto)
    {
        var book = new Book
        {
            Title = dto.Title,
            ISBN = dto.ISBN,
            PublishYear = dto.PublishYear,
            Category = dto.Category,
            Author = dto.Author,
            TotalQuantity = dto.TotalQuantity,
            AvailableQuantity = dto.AvailableQuantity
        };

        var result = await _bookService.AddBookAsync(book);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(UpdateBookDTO dto)
    {
        var book = new Book
        {
            Id = dto.Id,
            Title = dto.Title,
            ISBN = dto.ISBN,
            PublishYear = dto.PublishYear,
            Category = dto.Category,
            Author = dto.Author,
            TotalQuantity = dto.TotalQuantity,
            AvailableQuantity = dto.AvailableQuantity
        };

        var result = await _bookService.UpdateBookAsync(book);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBookAsync(id);
        return Ok(result);
    }
}