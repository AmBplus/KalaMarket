using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetMenuItemService;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.Web.Models.ViewComponents;

[ViewComponent]
public class GetSiteMenuComponent : ViewComponent
{
    public GetSiteMenuComponent(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    private IProductAggFacadeService ProductAggFacadeService { get; }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await ProductAggFacadeService.Common.Query.GetMenuItems.ExecuteAsync(new RequestGetMenuItem());
        return View("GetSiteMenu", result.Data);
    }
}