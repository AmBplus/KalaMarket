using KalaMarket.Application.HomePage.HomePage.MainSliders.Facade.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.MainSliders.Facade.Imp;

public class MainSliderCmdFacadeService : IMainSliderCmdFacadeService
{
    #region Fields
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    #endregion /Fields
    #region Constructor
    public MainSliderCmdFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    #endregion /Constructor

}