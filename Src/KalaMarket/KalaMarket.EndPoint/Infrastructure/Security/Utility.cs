namespace KalaMarket.EndPoint.Infrastructure.Security
{
    public static class Utility
    {
        //public const string AuthenticationScheme = "Cookies";

        public const string AuthenticationScheme =
            Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;

        public const string KalaMarketAuthCookieName = nameof(KalaMarketAuthCookieName);

        static Utility()
        {
        }
    }
}
