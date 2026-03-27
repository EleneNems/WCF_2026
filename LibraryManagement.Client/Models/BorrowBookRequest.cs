using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Client.Models
{
    public class BorrowBookRequest
    {
        public int BookId { get; set; }

        public int MemberId { get; set; }
    }
}
