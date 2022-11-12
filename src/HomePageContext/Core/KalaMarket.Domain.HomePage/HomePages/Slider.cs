using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.HomePage.HomePages;

public class Slider : BaseEntity<long>
{
    public Slider(string src, string link, SliderType sliderType)
    {
        Src = src;
        Link = link;
        SliderType = sliderType;
    }
    private Slider(){}
    public string Src { get; private set; }
    public string Link { get; private set; }
    public SliderType SliderType { get; private set; }

    public bool ChangeSliderType(SliderType sliderType)
    {
        SliderType = sliderType;
        return true;
    }

    public void Edit(string src, string link)
    {
        Src = src;
        Link = link;
    }
}