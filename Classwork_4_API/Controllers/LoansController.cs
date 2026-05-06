using Microsoft.AspNetCore.Mvc;
using Classwork_4_Application.DTOs;
using Classwork_4_Infrastructure.Services;
namespace Classwork_4_API.Controllers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly LoanService _loanService;

    public LoansController(LoanService loanService)
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
        var result = await _loanService.IssueBookAsync(
            dto.ReaderId,
            dto.BookId,
            dto.LoanDate,
            dto.DueDate
        );

        return Ok(result);
    }

    [HttpPost("return")]
    public async Task<IActionResult> ReturnBook(ReturnBookDTO dto)
    {
        var result = await _loanService.ReturnBookAsync(
            dto.LoanId,
            dto.ReturnDate,
            dto.Condition
        );

        return Ok(result);
    }
}