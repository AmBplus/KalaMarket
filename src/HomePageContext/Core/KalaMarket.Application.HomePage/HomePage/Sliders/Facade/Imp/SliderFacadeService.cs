using KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Imp;

public class SliderFacadeService : ISliderFacadeService
{
    #region Constructor

    public SliderFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Fields

    private ISliderCmdFacadeService? _cmd;
    private IMainSliderQueryFacadeService? _query;

    #endregion /Fields

    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ISliderCmdFacadeService Cmd => _cmd ??= new SliderCmdFacadeService(Context, Logger);

    public IMainSliderQueryFacadeService Query => _query ??= new MainSliderQueryFacadeService(Context, Logger);

    #endregion /Properties
}