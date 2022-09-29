using KalaMarket.Application.Product.Services.Product.ProductAggFacade;
using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetDetailProductForAdmin;
using KalaMarket.EndPoint.Infrastructure;

namespace KalaMarket.EndPoint.Pages.Admin.Products
{
    public class DetailModel : BasePageModel
    {
        public DetailModel(IProductAggFacadeService productAggFacadeService)
        {
            ProductAggFacadeService = productAggFacadeService;
        }
        public ProductDetailForAdmindto Product { get; set; }
        private IProductAggFacadeService ProductAggFacadeService { get; }
        public void OnGet(long id)
        {
            var result = ProductAggFacadeService.Product.Query.DetailProductForAdmin.Execute(new RequestGetDetailForAdmin()
            {
                Id = id
            });
            Product = result.Data;
            if (!result.IsSuccess)
            {
                AddToastError(result.Message);
                return;
            }

        }
    }
}
