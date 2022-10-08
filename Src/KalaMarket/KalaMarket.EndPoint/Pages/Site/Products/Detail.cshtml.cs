using KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductDetailForSite;
using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.EndPoint.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Utility;

namespace KalaMarket.EndPoint.Pages.Site.Products
{
    public class DetailModel : BasePageModel
    {
        public DetailModel(IProductAggFacadeService productAggFacadeService)
        {
            ProductAggFacadeService = productAggFacadeService;
        }

        private IProductAggFacadeService ProductAggFacadeService { get; }
        public ProductDetailForSiteDto ProductDetail { get; set; }

        public async Task<IActionResult> OnGet(long id, string slug)
        {
            var resultDto = await
            ProductAggFacadeService.Product.Query.ProductDetailForSite
                    .ExecuteAsync(new RequestGetDetailProductForSiteDto()
                    {
                        Id = id,
                    });
            ProductDetail = resultDto.Data;
            if (!resultDto.IsSuccess)
            {
                AddToastError(resultDto.Message);
            }
            return Page();
        }

        public RedirectToPageResult OnGetAddToCart(long productId)
        {
     
            var deviceId = CookiesManger.GetDeviceIdFromCookie(HttpContext);
            ProductAggFacadeService.CartService.Add(productId, deviceId,User.GetUserId());
            return RedirectToPage("Site/Index");

        }
    }
}
