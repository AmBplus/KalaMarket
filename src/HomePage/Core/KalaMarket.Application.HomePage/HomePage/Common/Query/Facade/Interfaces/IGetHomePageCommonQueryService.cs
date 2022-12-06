using KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersForSite;
using KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersWithTypeForSite;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Interfaces;

public interface IGetHomePageCommonQueryService
{
    IGetSlidersWithTypeForSiteService GetSlidersWithTypeForSite { get; }
    IGetSliderForSiteService GetSliderForSite { get; }
}