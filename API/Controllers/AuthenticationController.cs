using API.Core.Dtos;
using API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthenticationController : ApiControllerBase
{
    private readonly IUserService _userService;

    public AuthenticationController(IUserService userService) => _userService = userService;

    [HttpPost]
    public async Task<IActionResult> Authenticate(AuthenticationDto dto)
    {
        var response = await _userService.Authenticate(dto);

        if (response is null) return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}