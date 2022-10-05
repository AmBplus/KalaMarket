using KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSlider;
using KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;

public interface IMainSliderQueryFacadeService
{
    /// <summary>
    /// دریافت اسلایدر
    /// </summary>
    IGetSlidersService GetSlidersService { get; }
    /// <summary>
    /// دریافت اسلایدر ها
    /// </summary>
    IGetSliderService GetSliderService { get; }
}