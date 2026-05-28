using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Application.DTOs
{
    public class GuessRequestDto
    {
        public int GameId { get; set; }

        public string Word { get; set; } = string.Empty;
    }
}
