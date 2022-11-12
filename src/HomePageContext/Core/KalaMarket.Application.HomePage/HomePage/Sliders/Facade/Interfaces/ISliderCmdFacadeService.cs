using KalaMarket.Application.HomePage.HomePage.Sliders.Cmd.AddSlider;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;

public interface ISliderCmdFacadeService
{
    /// <summary>
    ///     اضافه کردن اسلایدر
    /// </summary>
    IAddSliderService AddSliderService { get; }
}