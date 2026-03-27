using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Entities
{
    public class Member
    {
        public Member()
        {
            BorrowTransactions = new HashSet<BorrowTransaction>();
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<BorrowTransaction> BorrowTransactions { get; set; }
    }
}
