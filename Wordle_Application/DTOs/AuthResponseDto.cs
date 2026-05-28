using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Application.DTOs
{
    public class AuthResponseDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}
