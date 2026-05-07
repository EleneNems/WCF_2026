using Classwork_4_Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.DTOs
{
    public class LoansDTO
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }
        public string ReaderName { get; set; } = null!;

        public int BookId { get; set; }
        public string BookTitle { get; set; } = null!;

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public ReturnCondition? ReturnCondition { get; set; }

        public bool IsReturned { get; set; }
        public decimal FineAmount { get; set; }
    }
}
