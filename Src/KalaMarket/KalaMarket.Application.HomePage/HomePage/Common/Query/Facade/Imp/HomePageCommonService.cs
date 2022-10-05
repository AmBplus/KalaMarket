using KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Imp;

public class HomePageCommonService : IHomePageCommonService
{
    private IGetHomePageCommonQueryService? _query;

    public HomePageCommonService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public IGetHomePageCommonQueryService Query
        => _query??=new GetHomePageCommonQueryService(Context,Logger);
}