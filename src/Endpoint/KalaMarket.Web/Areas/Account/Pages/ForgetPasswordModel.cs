using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.Web.Areas.Account.Pages;

public class ForgetPasswordModel : PageModel
{
    public RedirectToPageResult OnGet()
    {
        return RedirectToPage("/");
    }
}