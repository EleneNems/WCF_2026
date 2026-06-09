using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finals_Domain.Entities;

namespace Finals_Application.DTOs
{
    public class OrderUpdateDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
