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
            CookiesManeger cookiesManeger = new CookiesManeger();

            var result = ProductAggFacadeService.CartService.GetMyCart(cookiesManeger.GetDeviceId(HttpContext));
            if (result.IsSuccess != true)
            {
                AddToastError(result.Message);
            }
            Cart = result.Data;
        }

        public IActionResult OnGetRemoveCartItem(long cartItemId)
        {
            ProductAggFacadeService.CartService.RemoveFromCart()
        }
    }
}
