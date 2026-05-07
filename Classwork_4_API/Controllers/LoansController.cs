using Classwork_4_Application.DTOs;
using Classwork_4_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Classwork_4_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLoans()
    {
        var loans = await _loanService.GetLoansAsync();
        return Ok(loans);
    }

    [HttpPost("issue")]
    public async Task<IActionResult> IssueBook(IssueBookDTO dto)
    {
        var result = await _loanService.IssueBookAsync(dto);
        return Ok(result);
    }

    [HttpPost("return")]
    public async Task<IActionResult> ReturnBook(ReturnBookDTO dto)
    {
        var result = await _loanService.ReturnBookAsync(dto);
        return Ok(result);
    }
}