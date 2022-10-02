using KalaMarket.EndPoint.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Areas.Account.Pages
{
    public class SignoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(Utility.AuthenticationScheme);
            return RedirectToPage("/");
        }
    }
}
