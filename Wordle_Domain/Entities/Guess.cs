using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wordle_Domain.Entities
{
    public class Guess
{
    public int Id { get; set; }

    public int GameId { get; set; }

    public Game? Game { get; set; }

    public string Word { get; set; } = string.Empty;

    public int GuessNumber { get; set; }

    public string GuessResult { get; set; } = string.Empty;
}

}

