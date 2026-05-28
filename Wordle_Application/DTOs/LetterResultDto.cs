using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Application.DTOs
{
    public class LetterResultDto
    {
        public char Letter { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
