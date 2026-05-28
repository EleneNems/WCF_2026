using Microsoft.AspNetCore.Mvc;
using Wordle_Application.Interfaces;

namespace Wordle_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetStatistics(int userId)
    {
        var result = await _statisticsService.GetStatisticsAsync(userId);
        return Ok(result);
    }
}