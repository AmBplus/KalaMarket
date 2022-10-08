using KalaMarket.Application.Product.Services.ProductAgg.Carts;
using KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;
using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.EndPoint.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.AspNetCore.Utility;

namespace KalaMarket.EndPoint.Pages.Site.Carts
{
    public class IndexModel : BasePageModel
    {
        IProductAggFacadeService ProductAggFacadeService;
        public CartDto Cart { get; set; }
        public IndexModel(IProductAggFacadeService productAggFacadeService)
        {
            this.ProductAggFacadeService = productAggFacadeService;
        }

        public void OnGet()
        {
            
            var result = ProductAggFacadeService.CartService.GetMyCart(CookiesManger.GetDeviceIdFromCookie(HttpContext),HttpContext.User.GetUserId() );
            if (result.IsSuccess != true)
            {
                AddToastError(result.Message);
            }
            Cart = result.Data;
        }

        public IActionResult OnGetRemoveCartItem(long cartItemId)
        {
            var result = ProductAggFacadeService.CartService.RemoveFromCart(cartItemId,
                CookiesManger.GetDeviceIdFromCookie(HttpContext), User.GetUserId());
            if (!result.IsSuccess)
            {
                AddToastError(result.Message);
            }

            return RedirectToPage();
        }

        public IActionResult OnGetIncreaseCount(long cartItemId)
        {
            var result = ProductAggFacadeService.CartService.IncreaseCartItemCount(cartItemId,
                CookiesManger.GetDeviceIdFromCookie(HttpContext), User.GetUserId());
            if (!result.IsSuccess)
            {
                AddToastError(result.Message);
            }

            return RedirectToPage();
        }

        public IActionResult OnGetDecreaseCount(long cartItemId)
        {
            var result = ProductAggFacadeService.CartService.DecreaseCartItemCount(cartItemId,
                CookiesManger.GetDeviceIdFromCookie(HttpContext),User.GetUserId());
            if (!result.IsSuccess)
            {
                AddToastError(result.Message);
            }

            return RedirectToPage();
        }
    }
}
