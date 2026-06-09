using Finals_Domain.Entities;

namespace Finals_Domain.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<(IEnumerable<Order> Orders, int TotalCount)> GetPagedAsync(
        int pageNumber,
        int pageSize,
        DateTime? orderDateFrom,
        DateTime? orderDateTo);
}
