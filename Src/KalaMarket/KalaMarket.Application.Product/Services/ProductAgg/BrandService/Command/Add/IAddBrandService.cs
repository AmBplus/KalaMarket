using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Command.Add;

public interface IAddBrandService
{
    ResultDto<AddBrandServiceDto> Execute(RequestAddBrand requestAddBrand);
}