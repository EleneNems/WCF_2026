using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classwork_4_Domain.Entity;

public class Loan
{
    public int Id { get; set; }

    public int ReaderId { get; set; }
    public Reader Reader { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }

    public DateTime? ReturnDate { get; set; }
    public ReturnCondition? ReturnCondition { get; set; }

    public bool IsReturned { get; set; } = false;

    public decimal FineAmount { get; set; } = 0;
}

public enum ReturnCondition
{
    Good = 1,
    Damaged = 2,
    Lost = 3
}