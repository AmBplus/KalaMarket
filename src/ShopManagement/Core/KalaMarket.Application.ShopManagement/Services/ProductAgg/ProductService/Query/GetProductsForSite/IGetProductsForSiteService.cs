using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductsForSite;

public interface IGetProductsForSiteService
{
    ResultDto<ResultGetProductsForSiteDto> Execute(RequestGetProductsForSiteDto request);
    Task<ResultDto<ResultGetProductsForSiteDto>> ExecuteAsync(RequestGetProductsForSiteDto request);
}