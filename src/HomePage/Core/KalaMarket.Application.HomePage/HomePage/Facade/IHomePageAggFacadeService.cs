using KalaMarket.Application.HomePage.HomePage.Common.Query.Facade.Interfaces;
using KalaMarket.Application.HomePage.HomePage.Sliders.Facade.Interfaces;

namespace KalaMarket.Application.HomePage.HomePage.Facade;

public interface IHomePageAggFacadeService
{
    ISliderFacadeService Slider { get; }
    IHomePageCommonService Common { get; }
}