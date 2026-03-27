using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Entities
{
    public class Book
    {
        public Book()
        {
            BorrowTransactions = new HashSet<BorrowTransaction>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public int Quantity { get; set; }

        public int AvailableQuantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<BorrowTransaction> BorrowTransactions { get; set; }
    }
}
