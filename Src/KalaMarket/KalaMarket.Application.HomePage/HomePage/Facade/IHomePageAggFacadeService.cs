using KalaMarket.Application.HomePage.HomePage.MainSliders.Facade.Interfaces;

namespace KalaMarket.Application.HomePage.HomePage.Facade;

public interface IHomePageAggFacadeService
{
    IMainSliderFacadeService MainSliderFacadeService { get; }
}