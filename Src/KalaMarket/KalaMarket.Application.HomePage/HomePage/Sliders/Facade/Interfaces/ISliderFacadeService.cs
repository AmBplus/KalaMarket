namespace KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;

public interface ISliderFacadeService
{
    /// <summary>
    /// کامند ها
    /// </summary>
    ISliderCmdFacadeService Cmd { get; }
    /// <summary>
    /// کوئری ها
    /// </summary>
    IMainSliderQueryFacadeService Query { get; }
}