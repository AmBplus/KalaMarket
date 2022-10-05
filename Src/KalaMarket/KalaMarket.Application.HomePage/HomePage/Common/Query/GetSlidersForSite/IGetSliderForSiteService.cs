using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersForSite;

public interface IGetSliderForSiteService
{
    ResultDto<ResultGetSlidersForSiteDto> Execute(RequestGetSildersForSiteDto request);
    Task<ResultDto<ResultGetSlidersForSiteDto>> ExecuteAsync(RequestGetSildersForSiteDto request);
}