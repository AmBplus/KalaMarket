using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.Common.Query.GetCategorySite;

public interface IGetCategorySiteService
{
    ResultDto<IEnumerable<GetCategorySiteServiceDto>> Execute(RequestGetCategorySiteDto request);
   Task<ResultDto<IEnumerable<GetCategorySiteServiceDto>>> ExecuteAsync(RequestGetCategorySiteDto request);
}