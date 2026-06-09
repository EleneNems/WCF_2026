using Finals_Application.DTOs;
using Finals_Application.Exceptions;
using Finals_Domain.Entities;
using Finals_Domain.Interfaces;

namespace Finals_Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepo;
    private readonly IProductRepository _productRepo;

    public OrderService(IOrderRepository orderRepo, IProductRepository productRepo)
    {
        _orderRepo = orderRepo;
        _productRepo = productRepo;
    }

    public async Task<PagedResult<OrderReadDto>> GetPagedAsync(
        int pageNumber, int pageSize,
        DateTime? orderDateFrom, DateTime? orderDateTo)
    {
        if (pageNumber < 1) pageNumber = 1;
        if (pageSize < 1) pageSize = 10;

        var (orders, totalCount) = await _orderRepo.GetPagedAsync(pageNumber, pageSize, orderDateFrom, orderDateTo);
        int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        return new PagedResult<OrderReadDto>
        {
            Items = orders.Select(MapToDto),
            TotalCount = totalCount,
            TotalPages = totalPages,
            CurrentPage = pageNumber
        };
    }

    public async Task<OrderReadDto> GetByIdAsync(int id)
    {
        var order = await _orderRepo.GetByIdAsync(id);
        if (order == null)
            throw new NotFoundException($"Order with id {id} not found.");
        return MapToDto(order);
    }

    public async Task<OrderReadDto> CreateAsync(OrderCreateDto dto)
    {
        CheckQuantityRange(dto.Quantity);

        var product = await _productRepo.GetByIdAsync(dto.ProductId);
        if (product == null)
            throw new NotFoundException($"Product with id {dto.ProductId} not found.");

        if (string.IsNullOrWhiteSpace(dto.CustomerName))
            throw new ValidationException("CustomerName is required.");

        var order = new Order
        {
            CustomerName = dto.CustomerName,
            OrderDate = DateTime.UtcNow,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            Price = product.Price,   
            Product = product
        };

        await _orderRepo.AddAsync(order);
        await _orderRepo.SaveChangesAsync();

        return MapToDto(order);
    }

    public async Task<OrderReadDto> UpdateAsync(int id, OrderUpdateDto dto)
    {
        var order = await _orderRepo.GetByIdAsync(id);
        if (order == null)
            throw new NotFoundException($"Order with id {id} not found.");

        CheckQuantityRange(dto.Quantity);

        var product = await _productRepo.GetByIdAsync(dto.ProductId);
        if (product == null)
            throw new NotFoundException($"Product with id {dto.ProductId} not found.");

        if (string.IsNullOrWhiteSpace(dto.CustomerName))
            throw new ValidationException("CustomerName is required.");

        order.CustomerName = dto.CustomerName;
        order.Quantity = dto.Quantity;
        if (order.ProductId != dto.ProductId)
        {
            order.ProductId = dto.ProductId;
            order.Price = product.Price;
        }
        order.Product = product;

        await _orderRepo.UpdateAsync(order);
        await _orderRepo.SaveChangesAsync();

        return MapToDto(order);
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _orderRepo.GetByIdAsync(id);
        if (order == null)
            throw new NotFoundException($"Order with id {id} not found.");

        await _orderRepo.DeleteAsync(order);
        await _orderRepo.SaveChangesAsync();
    }

    
    private decimal CalculateTotalPrice(Order order)
        => order.Price * order.Quantity;   

    private void CheckQuantityRange(int quantity)
    {
        if (quantity < 1)
            throw new ValidationException("Quantity must be 1 or more.");
    }

    private OrderReadDto MapToDto(Order o)
    {
        var total = CalculateTotalPrice(o);
        return new OrderReadDto
        {
            Id = o.Id,
            CustomerName = o.CustomerName,
            OrderDate = o.OrderDate,
            ProductId = o.ProductId,
            ProductName = o.Product?.Name ?? string.Empty,
            Quantity = o.Quantity,
            TotalPrice = total,
            IsExpensive = total > 100
        };
    }
}