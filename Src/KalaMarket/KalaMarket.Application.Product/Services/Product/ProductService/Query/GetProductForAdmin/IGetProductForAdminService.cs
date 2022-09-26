using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductForAdmin;

public interface IGetProductForAdminService
{
    public ResultDto<GetProductForAdminDto> Execute(RequestGetProductForAdmin requestGetProductsForAdmin);
}