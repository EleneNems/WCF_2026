using Finals_Application.DTOs;
using Finals_Application.Exceptions;
using Finals_Domain.Entities;
using Finals_Domain.Interfaces;

namespace Finals_Application.Services;

public class CategoryService
{
    private readonly IRepository<Category> _categoryRepo;

    public CategoryService(IRepository<Category> categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<IEnumerable<CategoryReadDto>> GetAllAsync()
    {
        var categories = await _categoryRepo.GetAllAsync();
        return categories.Select(c => new CategoryReadDto { Id = c.Id, Name = c.Name });
    }

    public async Task<CategoryReadDto> GetByIdAsync(int id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category == null)
            throw new NotFoundException($"Category with id {id} not found.");

        return new CategoryReadDto { Id = category.Id, Name = category.Name };
    }

    public async Task<CategoryReadDto> CreateAsync(CategoryCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ValidationException("Category name is required.");

        var category = new Category { Name = dto.Name };
        await _categoryRepo.AddAsync(category);
        await _categoryRepo.SaveChangesAsync();

        return new CategoryReadDto { Id = category.Id, Name = category.Name };
    }
}
