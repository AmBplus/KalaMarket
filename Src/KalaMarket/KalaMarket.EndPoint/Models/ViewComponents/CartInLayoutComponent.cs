using KalaMarket.Application.Product.Services.ProductAgg.Carts;
using KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Utility;

namespace KalaMarket.EndPoint.Models.ViewComponents;

[ViewComponent]
public class CartInLayoutComponent : ViewComponent
{
    public CartInLayoutComponent(IProductAggFacadeService productAggFacadeService)
    {
        this.ProductAggFacadeService = productAggFacadeService;
    }

    private IProductAggFacadeService ProductAggFacadeService { get; }
    
    public IViewComponentResult Invoke()
    {
        var id = HttpContext.User.GetUserId();
        var result = ProductAggFacadeService.CartService.GetMyCart(CookiesManger.GetDeviceIdFromCookie(HttpContext),HttpContext.User.GetUserId());
        return View("CartInLayoutComponent", result.Data);
    }
}