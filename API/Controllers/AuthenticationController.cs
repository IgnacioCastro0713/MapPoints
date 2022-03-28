using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class AuthenticationController : ApiControllerBase
{

    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
    {
        _logger = logger;
    }
}