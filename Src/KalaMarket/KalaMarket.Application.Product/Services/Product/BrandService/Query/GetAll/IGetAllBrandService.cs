using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.BrandService.Query.GetAll;

public interface IGetAllBrandService
{
    ResultDto<GetAllBrandServiceDto> Execute(RequestGetAllBrandDto requestGetAllBrand);
}