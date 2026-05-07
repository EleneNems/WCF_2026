using Classwork_4_Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_4_Application.Interfaces
{
    public interface ILoanService
    {
        Task<List<LoansDTO>> GetLoansAsync();
        Task<string> IssueBookAsync(IssueBookDTO dto);
        Task<string> ReturnBookAsync(ReturnBookDTO dto);
    }
}
