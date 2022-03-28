using API.Core.Dtos;
using API.Core.Helpers;

namespace API.Core.Interfaces.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticationDto dto);
}