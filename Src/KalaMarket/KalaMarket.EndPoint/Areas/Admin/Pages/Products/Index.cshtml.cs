using KalaMarket.Application.Product.Services.Products.ProductAggFacade;
using KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductsForAdmin;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Shared;

namespace KalaMarket.EndPoint.Areas.Admin.Pages.Products
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IProductAggFacadeService productAggFacadeService)
        {
            ProductAggFacadeService = productAggFacadeService;
        }

        private IProductAggFacadeService ProductAggFacadeService { get; }
        public GetProductsForAdminDto Products { get; set; }
        public void OnGet(int page = 1, byte pageSize = KalaMarketConstants.Page.PageSize)
        {
            var result = ProductAggFacadeService.Product.Query.ProductsForAdmin.Execute(new RequestGetProductsForAdmin()
            {
                Page = page,
                PageSize = pageSize
            });
            if (!result.IsSuccess)
            {
                AddToastError(result.Message);
            }

            Products = result.Data;
        }
    }
}
