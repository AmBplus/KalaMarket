using System.Linq.Expressions;
using KalaMarket.Domain.HomePage.HomePages;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersWithTypeForSite;

public class RequestGetSlidersWithTypeForSiteDto
{
    public Expression<Func<Slider, bool>> Filter { get; set; }
}