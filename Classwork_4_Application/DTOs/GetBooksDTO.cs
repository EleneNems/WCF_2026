using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.DTOs
{
    public class GetBooksDTO
    {
        public string? Title { get; set; }
        public string? ISBN { get; set; }

        public int? AuthorId { get; set; }
        public int? CategoryId { get; set; }

        public string? AuthorName { get; set; }
        public string? CategoryName { get; set; }
    }
}
