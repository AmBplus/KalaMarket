using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Account
{
    public class ForgetPasswordModel : PageModel
    {
        public RedirectToPageResult OnGet()
        {
            return RedirectToPage("/");
        }
    }
}
