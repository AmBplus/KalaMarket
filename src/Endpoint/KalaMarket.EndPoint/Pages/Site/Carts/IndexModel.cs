using KalaMarket.Application.Product.Services.ProductAgg.Carts;
using KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.EndPoint.Pages.Site.Carts;

public class IndexModel : BasePageModel
{
    private IProductAggFacadeService ProductAggFacadeService;

    public IndexModel(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    public CartDto Cart { get; set; }

    public void OnGet()
    {
        var result = ProductAggFacadeService.CartService.GetMyCart(CookiesManger.GetDeviceIdFromCookie(HttpContext),
            HttpContext.User.GetUserId());
        if (result.IsSuccess != true) AddToastError(result.Message);
        Cart = result.Data;
    }

    public IActionResult OnGetRemoveCartItem(long cartItemId)
    {
        var result = ProductAggFacadeService.CartService.RemoveFromCart(cartItemId,
            CookiesManger.GetDeviceIdFromCookie(HttpContext), User.GetUserId());
        if (!result.IsSuccess) AddToastError(result.Message);

        return RedirectToPage();
    }

    public IActionResult OnGetIncreaseCount(long cartItemId)
    {
        var result = ProductAggFacadeService.CartService.IncreaseCartItemCount(cartItemId,
            CookiesManger.GetDeviceIdFromCookie(HttpContext), User.GetUserId());
        if (!result.IsSuccess) AddToastError(result.Message);

        return RedirectToPage();
    }

    public IActionResult OnGetDecreaseCount(long cartItemId)
    {
        var result = ProductAggFacadeService.CartService.DecreaseCartItemCount(cartItemId,
            CookiesManger.GetDeviceIdFromCookie(HttpContext), User.GetUserId());
        if (!result.IsSuccess) AddToastError(result.Message);

        return RedirectToPage();
    }
}