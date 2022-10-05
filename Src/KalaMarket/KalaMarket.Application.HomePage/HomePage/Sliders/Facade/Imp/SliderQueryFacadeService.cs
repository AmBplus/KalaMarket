using KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;
using KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSlider;
using KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Imp;

public class MainSliderQueryFacadeService : IMainSliderQueryFacadeService
{
    #region Fields
    private IGetSlidersService? _getSlidersService;
    private IGetSliderService? _getSliderService;
  
    #endregion /Fields
  
    #region Constructor
    public MainSliderQueryFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    #endregion /Constructor
   
    #region Properties
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public IGetSlidersService GetSlidersService
        => _getSlidersService ??= new GetSlidersService(Context, Logger);

    public IGetSliderService GetSliderService
        => _getSliderService ??= new GetSliderService(Context, Logger);
    #endregion /Properties
}