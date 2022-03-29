using API.Core.Dtos;
using API.Core.Helpers;
using API.Core.Models;

namespace API.Core.Interfaces.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticationDto dto);
    Task<User?> GetByEmail(string email);
}