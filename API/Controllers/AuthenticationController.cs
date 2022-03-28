using API.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthenticationController : ApiControllerBase
{
    private readonly IUserService _userService;
    
    public AuthenticationController(IUserService userService) => _userService = userService;
}