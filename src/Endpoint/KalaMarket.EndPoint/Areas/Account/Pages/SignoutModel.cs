using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.AspNetCore.Infrastructure.Security;

namespace KalaMarket.EndPoint.Areas.Account.Pages;

public class SignoutModel : PageModel
{
    public async Task<IActionResult> OnGetAsync(string returnUrl = null)
    {
        await HttpContext.SignOutAsync(SecurityUtility.AuthenticationScheme);
        return Redirect("/");
    }
}