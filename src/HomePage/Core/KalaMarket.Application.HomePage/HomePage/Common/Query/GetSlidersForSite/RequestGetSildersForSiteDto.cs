using System.Linq.Expressions;
using KalaMarket.Domain.HomePage.HomePages;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersForSite;

public class RequestGetSildersForSiteDto

{
    public Expression<Func<Slider, bool>> Filter { get; set; }
}