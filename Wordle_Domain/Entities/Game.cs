using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }

        public string TargetWord { get; set; } = string.Empty;

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime? EndDate { get; set; }

        public int Attempts { get; set; }

        public bool IsWin { get; set; }

        public List<Guess> Guesses { get; set; } = new();
        public int? UserId { get; set; }

        public User? User { get; set; }
    }
}