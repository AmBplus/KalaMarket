using KalaMarket.Application.Agg.Services;
using KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersForSite;
using KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersWithTypeForSite;
using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Shared;
using Mapster;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Pages.Site;

public class IndexModel : BasePageModel
{
    private readonly ILoggerManger<IndexModel> Logger;

    public IndexModel(ILoggerManger<IndexModel> logger, IKalaMarketAggServices kalaMarketAggServices)
    {
        Logger = logger;
        KalaMarketAggServices = kalaMarketAggServices;
    }

    private IKalaMarketAggServices KalaMarketAggServices { get; }

    public async Task OnGet()
    {
        var result = await KalaMarketAggServices.HomePageAggFacadeService.Common.Query.GetSlidersWithTypeForSite
            .ExecuteAsync(
                new RequestGetSlidersWithTypeForSiteDto
                {
                    Filter = x => x.SliderType != SliderType.MainSlider
                });

        if (!result.IsSuccess) AddToastError(result.Message);

        SetSilder(result.Data.Sliders);
    }

    private void SetSilder(IEnumerable<GetSlidersWithTypeForSiteDto> dataSliders)
    {
        HorizontalSponsored = dataSliders.Where(x => x.SliderType == SliderType.HorizontalSponsored)
            .Take(1).Select(x => x.Adapt<GetSlidersForSiteDto>()).FirstOrDefault();
        AmazingSlider = dataSliders.Where(x => x.SliderType == SliderType.AmazingSlider)
            .Select(x => x.Adapt<GetSlidersForSiteDto>());
        MultipleVerticalSponsored = dataSliders.Where(x => x.SliderType == SliderType.MultipleVerticalSponsored)
            .Take(4).Select(x => x.Adapt<GetSlidersForSiteDto>());
        SingleVerticalSponsored = dataSliders.Where(x => x.SliderType == SliderType.SingleVerticalSponsored)
            .Select(x => x.Adapt<GetSlidersForSiteDto>()).FirstOrDefault();
        SliderMoment = dataSliders.Where(x => x.SliderType == SliderType.SliderMoment)
            .Select(x => x.Adapt<GetSlidersForSiteDto>());
        AdPlacement = dataSliders.Where(x => x.SliderType == SliderType.AdPlacement).Take(2)
            .Select(x => x.Adapt<GetSlidersForSiteDto>());
    }

    #region ViewModel

    public GetSlidersForSiteDto HorizontalSponsored { get; set; }
    public IEnumerable<GetSlidersForSiteDto> MultipleVerticalSponsored { get; set; }
    public GetSlidersForSiteDto SingleVerticalSponsored { get; set; }
    public IEnumerable<GetSlidersForSiteDto> AmazingSlider { get; set; }
    public IEnumerable<GetSlidersForSiteDto> SliderMoment { get; set; }
    public IEnumerable<GetSlidersForSiteDto> AdPlacement { get; set; }

    #endregion
}