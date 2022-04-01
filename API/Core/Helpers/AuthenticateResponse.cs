﻿using API.Core.Models;

namespace API.Core.Helpers;

public class AuthenticateResponse
{
    public User User { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(User user, string token)
    {
        User = user;
        Token = token;
    }
}