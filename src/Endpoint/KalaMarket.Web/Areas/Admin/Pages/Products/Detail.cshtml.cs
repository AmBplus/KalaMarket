using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetDetailProductForAdmin;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Areas.Admin.Pages.Products;

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
        var result = ProductAggFacadeService.Product.Query.DetailProductForAdmin.Execute(new RequestGetDetailForAdmin
        {
            Id = id
        });
        Product = result.Data;
        if (!result.IsSuccess) AddToastError(result.Message);
    }
}