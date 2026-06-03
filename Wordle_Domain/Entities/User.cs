using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordle_Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = "";

        public string PasswordHash { get; set; } = "";

        public Statistic? Statistic { get; set; }
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
