using API.Core.Attributes;
using API.Core.Dtos;
using API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UserController : ApiControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) => _userService = userService;
    
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        await _userService.Register(dto);
        
        return Ok(new { message = "Registration successful" });
    }
}