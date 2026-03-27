using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Service.DTOs
{
    public class BorrowBookRequest
    {
        public int BookId { get; set; }

        public int MemberId { get; set; }
    }
}