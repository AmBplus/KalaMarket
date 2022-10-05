using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Domain.Products.ProductAgg;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;

public class RequestGetSlidersDto
{
    public int Page { get; set; } = 1;
    public byte PageSize { get; set; } = KalaMarket.Shared.KalaMarketConstants.Page.PageSize;

}