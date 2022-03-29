using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Core.Dtos;
using API.Core.Helpers;
using API.Core.Interfaces;
using API.Core.Interfaces.Services;
using API.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;


public class UserService: IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private const int TokenDurationDays = 7;
    private readonly AppSettings _appSettings;

    public UserService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
    {
        _unitOfWork = unitOfWork;
        _appSettings = appSettings.Value;
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticationDto dto)
    {
        var user = await _unitOfWork.UserRepository.GetByEmailAndPasswordOrDefaultAsync(dto);

        if (user is null) return null;

        var token = GenerateToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _unitOfWork.UserRepository.GetByEmailAsync(email);
    }

    private string GenerateToken(User model)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Email, model.Email)
        };

        var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(TokenDurationDays),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}