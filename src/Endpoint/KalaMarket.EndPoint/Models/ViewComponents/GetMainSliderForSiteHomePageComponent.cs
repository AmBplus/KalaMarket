using KalaMarket.Application.Agg.Services;
using KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersForSite;
using KalaMarket.Domain.HomePage.HomePages;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Models.ViewComponents;

[ViewComponent]
public class GetMainSliderForSiteHomePageComponent : ViewComponent
{
    public GetMainSliderForSiteHomePageComponent(IKalaMarketAggServices kalaMarketServices)
    {
        KalaMarketServices = kalaMarketServices;
    }

    private IKalaMarketAggServices KalaMarketServices { get; }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await KalaMarketServices.HomePageAggFacadeService.Common.Query.GetSliderForSite.ExecuteAsync(
            new RequestGetSildersForSiteDto
            {
                Filter = x => x.SliderType == SliderType.MainSlider
            });

        return View("GetMainSliderForSiteHomePageComponent", result.Data.Sliders);
    }
}