using API.Core.Models;

namespace API.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmail(string email);
}