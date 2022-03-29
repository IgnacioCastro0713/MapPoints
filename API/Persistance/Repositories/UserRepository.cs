using API.Core.Dtos;
using API.Core.Interfaces.Repositories;
using API.Core.Models;
using API.Persistance.DbContext;
using Microsoft.EntityFrameworkCore;

namespace API.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IApplicationDbContext _context;

    public UserRepository(IApplicationDbContext context) => _context = context;

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context
            .Users
            .SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(RegisterDto dto)
    {
        User user = new()
        {
            Email = dto.Email,
            Password = dto.Password,
            FirstName = dto.FirstName,
            LastName = dto.LastName
        };
        
        await _context.Users.AddAsync(user);
    }
}