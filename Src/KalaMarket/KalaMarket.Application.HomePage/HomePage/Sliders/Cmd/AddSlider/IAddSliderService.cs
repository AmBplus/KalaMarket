using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Cmd.AddSlider;

public interface IAddSliderService
{
    ResultDto Execute(RequestAddSliderServiceDto request);
}