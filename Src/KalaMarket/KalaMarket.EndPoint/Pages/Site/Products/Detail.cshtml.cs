using KalaMarket.Application.Product.Services.Product.ProductAggFacade;
using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductDetailForSite;
using KalaMarket.EndPoint.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> OnGet(long id,string slug)
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
    }
}
