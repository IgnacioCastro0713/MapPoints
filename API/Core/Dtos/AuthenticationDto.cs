using System.ComponentModel.DataAnnotations;

namespace API.Core.Dtos;

public class AuthenticationDto
{
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }
}