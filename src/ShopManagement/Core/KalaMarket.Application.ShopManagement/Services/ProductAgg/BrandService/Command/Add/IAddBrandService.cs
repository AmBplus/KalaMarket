using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Command.Add;

public interface IAddBrandService
{
    ResultDto<AddBrandServiceDto> Execute(RequestAddBrand requestAddBrand);
}