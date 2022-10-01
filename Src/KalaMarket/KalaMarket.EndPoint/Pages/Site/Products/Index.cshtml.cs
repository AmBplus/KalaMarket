using KalaMarket.Application.Product.Services.Product.ProductAggFacade;
using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForSite;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Resourses;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Pages.Site.Products
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IProductAggFacadeService productAggFacadeService)
        {
            ProductAggFacadeService = productAggFacadeService;
        }
        public ResultGetProductsForSiteDto ResultGetProducts {get; set; }
        private IProductAggFacadeService ProductAggFacadeService { get; }
        public async Task<IActionResult> OnGetAsync(int page = 1,string searchKey = null ,  long? categoryId = null)
        {
           var result = await ProductAggFacadeService.Product.Query.ProductsForSite.ExecuteAsync(new RequestGetProductsForSiteDto()
            {
                Page = page,
                CategoryId = categoryId,
                SearchKey = searchKey,
            });
           if (!result.IsSuccess)
           {
               AddToastError(ErrorMessages.ProblemOccurred);
           }
           ResultGetProducts = result.Data;
           return Page();
        }
    }
}
