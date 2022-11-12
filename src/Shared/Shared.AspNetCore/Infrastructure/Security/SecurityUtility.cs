﻿using Microsoft.AspNetCore.Authentication.Cookies;

namespace Shared.AspNetCore.Infrastructure.Security;

public static class SecurityUtility
{
    //public const string AuthenticationScheme = "Cookies";

    public const string AuthenticationScheme =
        CookieAuthenticationDefaults.AuthenticationScheme;

    public const string KalaMarketAuthCookieName = nameof(KalaMarketAuthCookieName);
}