using API.Core.Interfaces.Repositories;
using API.Core.Models;
using API.Persistance.DbContext;
using Microsoft.EntityFrameworkCore;

namespace API.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context) => _context = context;

    public async Task<User?> GetByEmail(string email)
    {
        return await _context
            .Users
            .SingleOrDefaultAsync(user => user.Email == email);
    }
}