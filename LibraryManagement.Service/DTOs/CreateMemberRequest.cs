using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Service.DTOs
{
    public class CreateMemberRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}