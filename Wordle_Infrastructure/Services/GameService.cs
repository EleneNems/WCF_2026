using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Wordle_Application.DTOs;
using Wordle_Application.Interfaces;
using Wordle_Domain.Entities;

namespace Wordle_Infrastructure.Services
{
    public class GameService : IGameService
    {
        private readonly AppDBContext _context;

        private readonly List<string> _words = new()
        {
        "apple", "grape", "house", "plant", "table", "chair", "water", "bread"
        };

        public GameService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<StartGameResponseDto> StartGameAsync(StartGameRequestDto request)
        {
            Random random = new Random();
            string targetWord = _words[random.Next(_words.Count)];

            Game game = new Game
            {
                TargetWord = targetWord,
                StartDate = DateTime.Now,
                Attempts = 0,
                IsWin = false,
                UserId = request.UserId
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return new StartGameResponseDto
            {
                GameId = game.Id,
                Message = "New game started successfully"
            };
        }

        public async Task<GuessResponseDto> GuessAsync(GuessRequestDto request)
        {
            string word = request.Word.ToLower();

            if (word.Length != 5)
                throw new Exception("Word must be exactly 5 letters.");

            Game? game = await _context.Games.Include(g => g.Guesses).FirstOrDefaultAsync(g => g.Id == request.GameId);

            if (game == null)
                throw new Exception("Game not found.");

            if (game.IsWin || game.EndDate != null)
                throw new Exception("This game is already finished.");

            if (game.Attempts >= 6)
                throw new Exception("Maximum attempts reached.");

            List<LetterResultDto> result = CheckGuess(word, game.TargetWord);

            game.Attempts++;

            if (word == game.TargetWord)
            {
                game.IsWin = true;
                game.EndDate = DateTime.Now;
            }
            else if (game.Attempts == 6)
            {
                game.EndDate = DateTime.Now;
            }

            Guess guess = new Guess
            {
                GameId = game.Id,
                Word = word,
                GuessNumber = game.Attempts,
                GuessResult = JsonSerializer.Serialize(result)
            };

            _context.Guesses.Add(guess);
            await _context.SaveChangesAsync();

            return new GuessResponseDto
            {
                GameId = game.Id,
                Guess = word,
                Attempt = game.Attempts,
                MaxAttempts = 6,
                IsWin = game.IsWin,
                IsFinished = game.EndDate != null,
                Result = result
            };
        }

        private List<LetterResultDto> CheckGuess(string guess, string targetWord)
        {
            List<LetterResultDto> result = new();

            for (int i = 0; i < guess.Length; i++)
            {
                string status;

                if (guess[i] == targetWord[i])
                    status = "correct";
                else if (targetWord.Contains(guess[i]))
                    status = "present";
                else
                    status = "absent";

                result.Add(new LetterResultDto
                {
                    Letter = guess[i],
                    Status = status
                });
            }

            return result;
        }
    }
}