using KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Imp;
using KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Interfaces;
using KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Imp;
using KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Facade;

public class HomePageAggFacadeService : IHomePageAggFacadeService
{

    #region Fields
    private ISliderFacadeService? _mainSliderFacadeService;
    private IHomePageCommonService? _common;

    #endregion /Fields
   
    #region Constructor
    public HomePageAggFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    #endregion /Constructor
   
    #region Properties
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ISliderFacadeService Slider =>
        _mainSliderFacadeService ??= new SliderFacadeService(Context, Logger);

    public IHomePageCommonService Common
        => _common ??= new HomePageCommonService(Context,Logger);

    #endregion /Properties
}