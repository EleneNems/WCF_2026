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
        var stat = await _context.Statistics.FirstOrDefaultAsync(s => s.UserId == userId);
        if (stat == null)
            return new StatisticsDto();

        int winPct = stat.GamesPlayed == 0 ? 0 : (int)Math.Round((double)stat.Wins / stat.GamesPlayed * 100);

        return new StatisticsDto
        {
            Played = stat.GamesPlayed,
            Wins = stat.Wins,
            WinPercentage = winPct,
            CurrentStreak = stat.CurrentStreak,
            MaxStreak = stat.MaxStreak,
            TotalPoints = stat.TotalPoints
        };
    }

    public async Task UpdateAfterGameAsync(int userId, bool isWin, int attempts)
    {
        var stat = await _context.Statistics.FirstOrDefaultAsync(s => s.UserId == userId);
        if (stat == null) return;

        stat.GamesPlayed++;

        if (isWin)
        {
            stat.Wins++;
            stat.CurrentStreak++;
            if (stat.CurrentStreak > stat.MaxStreak)
                stat.MaxStreak = stat.CurrentStreak;

            int points = (7 - attempts) * 10;
            stat.TotalPoints += points;
        }
        else
        {
            stat.CurrentStreak = 0;
        }

        await _context.SaveChangesAsync();
    }
}