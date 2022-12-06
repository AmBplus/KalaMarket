using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Query.GetAll;

public interface IGetAllBrandService
{
    ResultDto<GetAllBrandServiceDto> Execute(RequestGetAllBrandDto requestGetAllBrand);
}