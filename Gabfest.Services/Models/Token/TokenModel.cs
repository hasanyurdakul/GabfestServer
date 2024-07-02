﻿namespace Gabfest.Services;

public class TokenModel
{
    public string Username { get; set; }
    public string Role { get; set; }
    public string SignInKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
}
