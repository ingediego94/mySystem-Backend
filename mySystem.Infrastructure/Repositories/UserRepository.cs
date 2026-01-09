using mySystem.Domain.Entities;
using mySystem.Domain.Interfaces;
using mySystem.Infrastructure.Data;

namespace mySystem.Infrastructure.Repositories;

public class UserRepository : IGeneralRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository( AppDbContext context)
    {
        _context = context;
    }
    
    // -------------------------------------------
    
    // Get All:
    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    
    // Get By Id:
    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    
    // Create:
    public Task<User> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    
    // Update:
    public Task<User> UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    
    // Delete:
    public Task<bool> DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }
}