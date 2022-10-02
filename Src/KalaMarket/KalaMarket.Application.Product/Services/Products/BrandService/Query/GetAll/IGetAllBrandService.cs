using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Query.GetAll;

public interface IGetAllBrandService
{
    ResultDto<GetAllBrandServiceDto> Execute(RequestGetAllBrandDto requestGetAllBrand);
}