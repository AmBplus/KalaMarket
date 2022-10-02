using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Command.Add;

public interface IAddBrandService
{
    ResultDto<AddBrandServiceDto> Execute(RequestAddBrand requestAddBrand);
}