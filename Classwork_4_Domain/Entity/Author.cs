using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Domain.Entity
{
    public class Author
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public List<Book> Books { get; set; } = new();
    }
}
