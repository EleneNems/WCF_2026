using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle_Application.DTOs;

namespace Wordle_Application.Interfaces
{
    public interface IStatisticsService
    {
        Task<StatisticsDto> GetStatisticsAsync(int userId);
        Task UpdateAfterGameAsync(int userId, bool isWin, int attempts);
    }
}
