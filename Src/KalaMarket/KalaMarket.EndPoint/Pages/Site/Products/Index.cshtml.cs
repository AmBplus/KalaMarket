using KalaMarket.Application.Product.Services.Product.ProductAggFacade;
using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForSite;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Resourses;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGet(int page = 1)
        {
           var result = ProductAggFacadeService.Product.Query.ProductsForSite.Execute(new RequestGetProductsForSiteDto()
            {
                Page = page
            });
           if (!result.IsSuccess)
           {
               AddToastError(ErrorMessages.ProblemOccurred);
           }
           ResultGetProducts = result.Data;
        }
    }
}
