using KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Interfaces;
using KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersForSite;
using KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersWithTypeForSite;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Imp;

public class GetHomePageCommonQueryService : IGetHomePageCommonQueryService
{
    private IGetSliderForSiteService? _getSliderForSite;
    private IGetSlidersWithTypeForSiteService? _getSlidersWithTypeForSite;


    public GetHomePageCommonQueryService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public IGetSlidersWithTypeForSiteService GetSlidersWithTypeForSite 
        => _getSlidersWithTypeForSite ??= new GetSlidersWithTypeForSiteService(Context,Logger);

    IGetSliderForSiteService IGetHomePageCommonQueryService.GetSliderForSite
        => _getSliderForSite ??= new GetSliderForSiteService(Context,Logger);

      
}