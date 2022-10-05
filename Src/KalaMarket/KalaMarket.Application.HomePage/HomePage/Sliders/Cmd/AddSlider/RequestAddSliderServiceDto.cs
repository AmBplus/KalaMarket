using KalaMarket.Domain.HomePage.HomePages;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Cmd.AddSlider;

public class RequestAddSliderServiceDto
{
    public string Src { get; set; }
    public string Link { get; set; }
    public SliderType SliderType { get; set; } = SliderType.MainSlider;
}