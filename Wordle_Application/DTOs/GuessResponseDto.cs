using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Application.DTOs
{
    public class GuessResponseDto
    {
        public int GameId { get; set; }

        public string Guess { get; set; } = string.Empty;

        public int Attempt { get; set; }

        public int MaxAttempts { get; set; } = 6;

        public bool IsWin { get; set; }

        public bool IsFinished { get; set; }

        public List<LetterResultDto> Result { get; set; } = new();
    }
}
