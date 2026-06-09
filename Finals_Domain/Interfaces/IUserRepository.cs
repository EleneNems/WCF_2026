using Finals_Domain.Entities;

namespace Finals_Domain.Interfaces;

public interface IUserRepository
{
    Task<ApplicationUser?> GetByUsernameAsync(string username);
    Task AddAsync(ApplicationUser user);
    Task SaveChangesAsync();
}
