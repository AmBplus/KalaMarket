using KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSlider;
using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;

public class ResultGetSlidersDto
{
    public IEnumerable<ResultGetSliderDto> Sliders { get; set; }
    public int Page { get; set; } = 1;
    public int RecordCount { get; set; } = 1;
    public byte PageSize { get; set; } = KalaMarketConstants.Page.PageSize;
}