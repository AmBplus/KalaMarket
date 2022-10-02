using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductForAdmin;

public interface IGetProductForAdminService
{
    public ResultDto<GetProductForAdminDto> Execute(RequestGetProductForAdmin requestGetProductsForAdmin);
}