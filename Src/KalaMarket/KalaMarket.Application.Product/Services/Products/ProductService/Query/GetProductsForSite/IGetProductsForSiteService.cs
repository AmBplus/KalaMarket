using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductsForSite;

public interface IGetProductsForSiteService
{
    ResultDto<ResultGetProductsForSiteDto> Execute(RequestGetProductsForSiteDto request);
    Task<ResultDto<ResultGetProductsForSiteDto>> ExecuteAsync(RequestGetProductsForSiteDto request);
}
