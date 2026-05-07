using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.DTOs;

public class UpdateBookDTO
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string ISBN { get; set; } = null!;
    public int PublishYear { get; set; }

    public int AuthorId { get; set; }
    public int CategoryId { get; set; }

    public int TotalQuantity { get; set; }
    public int AvailableQuantity { get; set; }
}