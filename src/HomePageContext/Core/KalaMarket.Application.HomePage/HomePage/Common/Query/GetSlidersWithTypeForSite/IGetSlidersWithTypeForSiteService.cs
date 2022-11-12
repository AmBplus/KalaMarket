using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersWithTypeForSite;

public interface IGetSlidersWithTypeForSiteService
{
    ResultDto<ResultGetSlidersWithTypeForSiteDto> Execute(RequestGetSlidersWithTypeForSiteDto request);
    Task<ResultDto<ResultGetSlidersWithTypeForSiteDto>> ExecuteAsync(RequestGetSlidersWithTypeForSiteDto request);
}