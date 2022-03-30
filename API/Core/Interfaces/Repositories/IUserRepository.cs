using API.Core.Dtos;
using API.Core.Models;

namespace API.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User model);
}