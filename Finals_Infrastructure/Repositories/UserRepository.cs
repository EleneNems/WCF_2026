using Finals_Domain.Entities;
using Finals_Domain.Interfaces;
using Finals_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Finals_Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StoreDbContext _context;

    public UserRepository(StoreDbContext context)
    {
        _context = context;
    }

    public async Task<ApplicationUser?> GetByUsernameAsync(string username) =>
        await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

    public async Task AddAsync(ApplicationUser user) =>
        await _context.Users.AddAsync(user);

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();
}
