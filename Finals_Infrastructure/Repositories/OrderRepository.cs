using Finals_Domain.Entities;
using Finals_Domain.Interfaces;
using Finals_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Finals_Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(StoreDbContext context) : base(context) { }

    public async Task<(IEnumerable<Order> Orders, int TotalCount)> GetPagedAsync(
        int pageNumber, int pageSize,
        DateTime? orderDateFrom, DateTime? orderDateTo)
    {
        var query = _context.Orders.Include(o => o.Product).AsQueryable();

        if (orderDateFrom.HasValue)
            query = query.Where(o => o.OrderDate >= orderDateFrom.Value);

        if (orderDateTo.HasValue)
            query = query.Where(o => o.OrderDate <= orderDateTo.Value);

        int totalCount = await query.CountAsync();

        var orders = await query
            .OrderByDescending(o => o.OrderDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (orders, totalCount);
    }

    public new async Task<Order?> GetByIdAsync(int id) =>
        await _context.Orders.Include(o => o.Product).FirstOrDefaultAsync(o => o.Id == id);
}
