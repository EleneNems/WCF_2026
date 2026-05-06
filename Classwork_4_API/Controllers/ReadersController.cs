using Microsoft.AspNetCore.Mvc;
using Classwork_4_Application.DTOs;
using Classwork_4_Domain.Entity;
using Classwork_4_Infrastructure.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Classwork_4_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReadersController : ControllerBase
{
    private readonly ReaderService _readerService;

    public ReadersController(ReaderService readerService)
    {
        _readerService = readerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReaders([FromQuery] ReaderStatus? status)
    {
        var readers = await _readerService.GetReadersAsync(status);
        return Ok(readers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReaderById(int id)
    {
        var reader = await _readerService.GetReaderByIdAsync(id);

        if (reader == null)
            return NotFound("Reader not found.");

        return Ok(reader);
    }

    [HttpPost]
    public async Task<IActionResult> AddReader(CreateReaderDTO dto)
    {
        var reader = new Reader
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PersonalNumber = dto.PersonalNumber,
            Phone = dto.Phone,
            Email = dto.Email
        };

        var result = await _readerService.AddReaderAsync(reader);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateReader(UpdateReaderDTO dto)
    {
        var reader = new Reader
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PersonalNumber = dto.PersonalNumber,
            Phone = dto.Phone,
            Email = dto.Email,
            Status = dto.Status
        };

        var result = await _readerService.UpdateReaderAsync(reader);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReader(int id)
    {
        var result = await _readerService.DeleteReaderAsync(id);
        return Ok(result);
    }
}