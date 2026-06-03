using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Wordle_Application.DTOs;
using Wordle_Application.Interfaces;
using Wordle_Infrastructure;

namespace Wordle_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly AppDBContext _context;

        public GamesController(
            IGameService gameService,
            AppDBContext context)
        {
            _gameService = gameService;
            _context = context;
        }

        [HttpPost("start")]
        [Authorize]
        public async Task<IActionResult> StartGame([FromBody] StartGameRequestDto request)
        {
            var result = await _gameService.StartGameAsync(request);
            return Ok(result);
        }

        [HttpPost("guess")]
        [Authorize]
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetGames()
        {
            int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var games = await _context.Games
                .Where(g => g.UserId == userId)
                .Select(g => new
                {
                    g.Id,
                    g.StartDate,
                    g.EndDate,
                    g.Attempts,
                    g.IsWin
                })
                .ToListAsync();

            return Ok(games);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetGame(int id)
        {
            int userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var game = await _context.Games
                .Include(g => g.Guesses)
                .FirstOrDefaultAsync(g =>
                    g.Id == id &&
                    g.UserId == userId);

            if (game == null)
                return NotFound();

            return Ok(game);
        }
    }
}