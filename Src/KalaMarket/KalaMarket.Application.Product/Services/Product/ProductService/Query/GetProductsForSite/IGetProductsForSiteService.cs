using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForSite;

public interface IGetProductsForSiteService
{
    ResultDto<ResultGetProductsForSiteDto> Execute(RequestGetProductsForSiteDto request);
}
