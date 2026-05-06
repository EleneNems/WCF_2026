using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classwork_4_Domain.Entity;

namespace Classwork_4_Application.DTOs;

public class ReturnBookDTO
{
    public int LoanId { get; set; }

    public DateTime ReturnDate { get; set; }

    public ReturnCondition Condition { get; set; }
}