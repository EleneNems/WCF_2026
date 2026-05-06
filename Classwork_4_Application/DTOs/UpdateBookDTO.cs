using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.DTOs;

public class UpdateBookDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int PublishYear { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;

    public int TotalQuantity { get; set; }
    public int AvailableQuantity { get; set; }
}