using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductDetailForSite;

public interface IGetProductDetailForSiteService
{
    ResultDto<ProductDetailForSiteDto> Execute(RequestGetDetailProductForSiteDto request);
    Task<ResultDto<ProductDetailForSiteDto>> ExecuteAsync(RequestGetDetailProductForSiteDto request);
}