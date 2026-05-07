using Classwork_4_Application.DTOs;
using Classwork_4_Application.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Classwork_4_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReadersController : ControllerBase
{
    private readonly IReaderService _readerService;

    public ReadersController(IReaderService readerService)
    {
        _readerService = readerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReaders([FromQuery] GetReadersDTO filter)
    {
        var readers = await _readerService.GetReadersAsync(filter);
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
        var result = await _readerService.AddReaderAsync(dto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateReader(UpdateReaderDTO dto)
    {
        var result = await _readerService.UpdateReaderAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReader(int id)
    {
        var result = await _readerService.DeleteReaderAsync(id);
        return Ok(result);
    }
}