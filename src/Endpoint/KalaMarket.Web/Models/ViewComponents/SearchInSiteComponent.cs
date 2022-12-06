using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetCategorySite;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.Web.Models.ViewComponents;

[ViewComponent]
public class SearchInSiteComponent : ViewComponent
{
    public SearchInSiteComponent(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    private IProductAggFacadeService ProductAggFacadeService { get; }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result =
            await ProductAggFacadeService.Common.Query.GetCategoriesSite.ExecuteAsync(new RequestGetCategorySiteDto());
        return View("SearchInSiteComponent", result.Data);
    }
}