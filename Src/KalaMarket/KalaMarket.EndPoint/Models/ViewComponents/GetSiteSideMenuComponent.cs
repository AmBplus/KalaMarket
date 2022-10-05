using KalaMarket.Application.Product.Services.ProductAgg.Common.Query.GetMenuItemService;
using KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Models.ViewComponents;
[ViewComponent]
public class GetSiteSideMenuComponent : ViewComponent
{
    public GetSiteSideMenuComponent(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    private IProductAggFacadeService ProductAggFacadeService { get; }
    public async Task<IViewComponentResult> InvokeAsync()
    {


        return View("GetSiteSideMenuComponent",
            (await ProductAggFacadeService.Common.Query.GetMenuItems.ExecuteAsync(new RequestGetMenuItem() { })).Data);
    }
}