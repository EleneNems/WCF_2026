using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Application.DTOs
{
    public class StartGameResponseDto
    {
        public int GameId { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
