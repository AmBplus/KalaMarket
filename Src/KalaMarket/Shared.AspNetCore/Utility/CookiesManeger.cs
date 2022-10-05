using Microsoft.AspNetCore.Http;

namespace Shared.AspNetCore.Utility
{
    public class CookiesManeger
    {
        public void Add(HttpContext context, string token, string value)
        {
            context.Response.Cookies.Append(token, value, getCookieOptions(context));
        }

        public bool Contains(HttpContext context, string token)
        {
            return context.Request.Cookies.ContainsKey(token);
        }

        public string GetValue(HttpContext context, string token)
        {
            string cookieValue;
            if (!context.Request.Cookies.TryGetValue(token, out cookieValue))
            {
                return null;
            }
            return  cookieValue ;
        }

        public void Remove(HttpContext context, string token)
        {
            if (context.Request.Cookies.ContainsKey(token))
            {
                context.Response.Cookies.Delete(token);
            }
        }

 
        public Guid GetDeviceId(HttpContext context)
        {
          string browserId=   GetValue(context, "DeviceId");
            if(browserId== null)
            {
                string value = Guid.NewGuid().ToString();
                Add(context, "DeviceId", value);
                browserId = value;
            }
            Guid guidBowser;
            Guid.TryParse(browserId, out guidBowser);
            return guidBowser ;
        }
        private CookieOptions getCookieOptions(HttpContext context)
        {
            return new CookieOptions
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                Expires = DateTime.Now.AddDays(100),
            };
        }
    }
}
