using Classwork_4_Application.DTOs;
using Classwork_4_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Classwork_4_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks([FromQuery] GetBooksDTO filter)
    {
        var books = await _bookService.GetBooksAsync(filter);
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
        var result = await _bookService.AddBookAsync(dto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(UpdateBookDTO dto)
    {
        var result = await _bookService.UpdateBookAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _bookService.DeleteBookAsync(id);
        return Ok(result);
    }
}