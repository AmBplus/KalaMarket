using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Models.ViewComponents;

[ViewComponent]
public class CartInLayoutComponent : ViewComponent
{
    public CartInLayoutComponent(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    private IProductAggFacadeService ProductAggFacadeService { get; }

    public IViewComponentResult Invoke()
    {
        var id = HttpContext.User.GetUserId();
        var result = ProductAggFacadeService.CartService.GetMyCart(CookiesManger.GetDeviceIdFromCookie(HttpContext),
            HttpContext.User.GetUserId());
        return View("CartInLayoutComponent", result.Data);
    }
}