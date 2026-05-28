using Microsoft.AspNetCore.Mvc;
using Wordle_Application.DTOs;
using Wordle_Application.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wordle_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("start")]
        public async Task<IActionResult> StartGame([FromBody] StartGameRequestDto request)
        {
            var result = await _gameService.StartGameAsync(request);
            return Ok(result);
        }

        [HttpPost("guess")]
        public async Task<IActionResult> Guess([FromBody] GuessRequestDto request)
        {
            try
            {
                var result = await _gameService.GuessAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
