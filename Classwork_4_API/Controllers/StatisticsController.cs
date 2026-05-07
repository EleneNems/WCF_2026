using Classwork_4_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Classwork_4_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetStatistics()
    {
        var statistics = await _statisticsService.GetStatisticsAsync();
        return Ok(statistics);
    }
}