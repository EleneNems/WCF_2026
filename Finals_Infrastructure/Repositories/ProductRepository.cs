using Finals_Domain.Entities;
using Finals_Domain.Interfaces;
using Finals_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Finals_Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(StoreDbContext context) : base(context) { }

    public async Task<IEnumerable<Product>> GetFilteredAsync(
        decimal? minPrice, decimal? maxPrice, int? categoryId,
        string? sortBy, string? sortDirection)
    {
        var query = _context.Products.Include(p => p.Category).AsQueryable();

        if (minPrice.HasValue)
            query = query.Where(p => p.Price >= minPrice.Value);

        if (maxPrice.HasValue)
            query = query.Where(p => p.Price <= maxPrice.Value);

        if (categoryId.HasValue)
            query = query.Where(p => p.CategoryId == categoryId.Value);

        bool descending = sortDirection?.ToLower() == "desc";

        query = sortBy?.ToLower() switch
        {
            "price" => descending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
            "name"  => descending ? query.OrderByDescending(p => p.Name)  : query.OrderBy(p => p.Name),
            _       => query.OrderBy(p => p.Id)
        };

        return await query.ToListAsync();
    }

    public new async Task<Product?> GetByIdAsync(int id) =>
        await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
}
