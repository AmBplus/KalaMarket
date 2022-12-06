using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Controllers;

[ApiController]
[Area("site")]
[Route("api/[controller]")]
public class Cart : ControllerBase
{
    public Cart(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    private IProductAggFacadeService ProductAggFacadeService { get; }

    [HttpDelete("{cartItemId}")]
    public async Task<IActionResult> Delete(long cartItemId)
    {
        var result = ProductAggFacadeService.CartService.RemoveFromCart(cartItemId,
            CookiesManger.GetDeviceIdFromCookie(HttpContext), User.GetUserId());
        if (!result.IsSuccess) return BadRequest(new { msg = result.Message });
        return Ok(new { msg = result.Message });
    }
}