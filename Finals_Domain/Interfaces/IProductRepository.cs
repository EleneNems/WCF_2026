using Finals_Domain.Entities;

namespace Finals_Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetFilteredAsync(
        decimal? minPrice,
        decimal? maxPrice,
        int? categoryId,
        string? sortBy,
        string? sortDirection);
}
