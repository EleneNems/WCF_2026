using Finals_Application.DTOs;
using Finals_Application.Exceptions;
using Finals_Domain.Entities;
using Finals_Domain.Interfaces;

namespace Finals_Application.Services;

public class ProductService
{
    private readonly IProductRepository _productRepo;
    private readonly IRepository<Category> _categoryRepo;

    public ProductService(IProductRepository productRepo, IRepository<Category> categoryRepo)
    {
        _productRepo = productRepo;
        _categoryRepo = categoryRepo;
    }

    public async Task<IEnumerable<ProductReadDto>> GetFilteredAsync(
        decimal? minPrice, decimal? maxPrice, int? categoryId,
        string? sortBy, string? sortDirection)
    {
        var products = await _productRepo.GetFilteredAsync(minPrice, maxPrice, categoryId, sortBy, sortDirection);
        return products.Select(MapToDto);
    }

    public async Task<ProductReadDto> GetByIdAsync(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            throw new NotFoundException($"Product with id {id} not found.");
        return MapToDto(product);
    }

    public async Task<ProductReadDto> CreateAsync(ProductCreateDto dto)
    {
        ValidateProduct(dto.Name, dto.Price, dto.CategoryId);

        var category = await _categoryRepo.GetByIdAsync(dto.CategoryId);
        if (category == null)
            throw new NotFoundException($"Category with id {dto.CategoryId} not found.");

        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };

        await _productRepo.AddAsync(product);
        await _productRepo.SaveChangesAsync();

        product.Category = category;
        return MapToDto(product);
    }

    public async Task<ProductReadDto> UpdateAsync(int id, ProductUpdateDto dto)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            throw new NotFoundException($"Product with id {id} not found.");

        ValidateProduct(dto.Name, dto.Price, dto.CategoryId);

        var category = await _categoryRepo.GetByIdAsync(dto.CategoryId);
        if (category == null)
            throw new NotFoundException($"Category with id {dto.CategoryId} not found.");

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;
        product.Category = category;

        await _productRepo.UpdateAsync(product);
        await _productRepo.SaveChangesAsync();

        return MapToDto(product);
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _productRepo.GetByIdAsync(id);
        if (product == null)
            throw new NotFoundException($"Product with id {id} not found.");

        await _productRepo.DeleteAsync(product);
        await _productRepo.SaveChangesAsync();
    }

    private void ValidateProduct(string name, decimal price, int categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Product name is required.");
        if (price <= 0)
            throw new ValidationException("Price must be greater than 0.");
        if (categoryId <= 0)
            throw new ValidationException("CategoryId must be valid.");
    }

    private ProductReadDto MapToDto(Product p) => new ProductReadDto
    {
        Id = p.Id,
        Name = p.Name,
        Price = p.Price,
        CategoryId = p.CategoryId,
        CategoryName = p.Category?.Name ?? string.Empty
    };
}
