using KalaMarket.Application.HomePage.HomePage.MainSliders.Facade.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.MainSliders.Facade.Imp;

public class MainSliderFacadeService : IMainSliderFacadeService
{

    #region Fields
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    #endregion /Fields
    #region Constructor
    public MainSliderFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    #endregion /Constructor
}