using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Domain.Entity
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublishYear { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public int TotalQuantity { get; set; }
        public int AvailableQuantity { get; set; }

        public List<Loan> Loans { get; set; } = new();
    }
}
