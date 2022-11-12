using KalaMarket.Domain.HomePage.HomePages;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersWithTypeForSite;

public class GetSlidersWithTypeForSiteDto
{
    public long Id { get; set; }
    public string Link { get; set; }
    public string Src { get; set; }
    public SliderType SliderType { get; set; }
}