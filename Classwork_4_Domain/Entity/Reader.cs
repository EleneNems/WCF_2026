using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Domain.Entity;

public class Reader
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PersonalNumber { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public ReaderStatus Status { get; set; } = ReaderStatus.Active;

    public List<Loan> Loans { get; set; } = new();
}

public enum ReaderStatus
{
    Active = 1,
    Blocked = 2,
    Cancelled = 3
}