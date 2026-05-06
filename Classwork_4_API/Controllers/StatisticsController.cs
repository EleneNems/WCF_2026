using Microsoft.AspNetCore.Mvc;
using Classwork_4_Infrastructure.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Classwork_4_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly StatisticsService _statisticsService;

    public StatisticsController(StatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStatistics()
    {
        var result = new
        {
            TotalBooksQuantity = await _statisticsService.GetTotalBooksQuantityAsync(),
            AvailableBooksQuantity = await _statisticsService.GetAvailableBooksQuantityAsync(),
            IssuedBooksCount = await _statisticsService.GetIssuedBooksCountAsync(),
            LateReturnsCount = await _statisticsService.GetLateReturnsCountAsync(),
            BlockedReadersCount = await _statisticsService.GetBlockedReadersCountAsync(),
            MostIssuedBook = await _statisticsService.GetMostIssuedBookAsync(),
            MostActiveReader = await _statisticsService.GetMostActiveReaderAsync()
        };

        return Ok(result);
    }
}