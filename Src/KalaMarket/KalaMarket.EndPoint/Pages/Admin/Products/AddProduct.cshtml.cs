using _01_Framework.AspCore.CheckContentType;
using _01_Framework.AspCore.Utility;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Admin.Products
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public IFormFile Image { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost([FromServices] IWebHostEnvironment hostEnvironment)
        {
            if (Image.FileIsValidImage())
            {
                var extension = Path.GetExtension(Image.FileName);
                var fileName =await Image.SaveFormFile(
                    Path.Combine(hostEnvironment.WebRootPath, KalaMarketConstants.FolderPath.ProductPath), extension);
            }
            return Page();
        }
    }
}
