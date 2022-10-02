using KalaMarket.Application.HomePage.HomePage.MainSliders.Facade.Imp;
using KalaMarket.Application.HomePage.HomePage.MainSliders.Facade.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Facade;

public class HomePageAggFacadeService : IHomePageAggFacadeService
{

    #region Fields
    private IMainSliderFacadeService? _mainSliderFacadeService;
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    #endregion /Fields
    #region Constructor
    public HomePageAggFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    #endregion /Constructor

    public IMainSliderFacadeService MainSliderFacadeService =>
        _mainSliderFacadeService ??= new MainSliderFacadeService(Context, Logger);
}