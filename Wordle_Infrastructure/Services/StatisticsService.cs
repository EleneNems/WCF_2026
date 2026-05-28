using Microsoft.EntityFrameworkCore;
using Wordle_Application.DTOs;
using Wordle_Application.Interfaces;

namespace Wordle_Infrastructure.Services;

public class StatisticsService : IStatisticsService
{
    private readonly AppDBContext _context;

    public StatisticsService(AppDBContext context)
    {
        _context = context;
    }

    public async Task<StatisticsDto> GetStatisticsAsync(int userId)
    {
        var games = await _context.Games
            .Where(g => g.UserId == userId && g.EndDate != null)
            .OrderBy(g => g.EndDate)
            .ToListAsync();

        int played = games.Count;
        int wins = games.Count(g => g.IsWin);

        int winPercentage = played == 0 ? 0 : (int)Math.Round((double)wins / played * 100);

        int currentStreak = 0;
        for (int i = games.Count - 1; i >= 0; i--)
        {
            if (games[i].IsWin)
                currentStreak++;
            else
                break;
        }

        int maxStreak = 0;
        int tempStreak = 0;

        foreach (var game in games)
        {
            if (game.IsWin)
            {
                tempStreak++;
                if (tempStreak > maxStreak)
                    maxStreak = tempStreak;
            }
            else
            {
                tempStreak = 0;
            }
        }

        return new StatisticsDto
        {
            Played = played,
            Wins = wins,
            WinPercentage = winPercentage,
            CurrentStreak = currentStreak,
            MaxStreak = maxStreak
        };
    }
}