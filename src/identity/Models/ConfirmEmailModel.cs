﻿namespace IdentityProvider.Models;

public class ConfirmEmailModel
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string Origin { get; set; }
}