using KalaMarket.Application.HomePage.HomePage.Sliders.Cmd.AddSlider;
using KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Imp;

public class SliderCmdFacadeService : ISliderCmdFacadeService
{
    #region Fields

    private IAddSliderService? _addMainSliderService;

    #endregion /Fields

    #region Constructor

    public SliderCmdFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public IAddSliderService AddSliderService =>
        _addMainSliderService ??= new AddSliderService(Context, Logger);

    #endregion /Properties
}