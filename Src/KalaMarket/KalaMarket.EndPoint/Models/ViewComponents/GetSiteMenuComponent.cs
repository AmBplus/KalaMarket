using KalaMarket.Application.Product.Services.ProductAgg.Common.Query.GetMenuItemService;
using KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Models.ViewComponents;

[ViewComponent]
public class GetSiteMenuComponent : ViewComponent
{
    private IProductAggFacadeService ProductAggFacadeService { get; }
    public GetSiteMenuComponent(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await ProductAggFacadeService.Common.Query.GetMenuItems.ExecuteAsync(new RequestGetMenuItem());
        return View("GetSiteMenu", result.Data);
    }
}