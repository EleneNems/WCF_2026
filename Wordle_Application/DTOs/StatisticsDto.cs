using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Application.DTOs
{
    public class StatisticsDto
    {
        public int Played { get; set; }
        public int Wins { get; set; }
        public int WinPercentage { get; set; }
        public int CurrentStreak { get; set; }
        public int MaxStreak { get; set; }
        public int TotalPoints { get; set; }
    }
}
