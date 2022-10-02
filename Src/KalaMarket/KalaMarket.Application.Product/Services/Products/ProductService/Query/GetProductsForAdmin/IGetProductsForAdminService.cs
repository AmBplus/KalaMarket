using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductsForAdmin;

public interface IGetProductsForAdminService
{
    public ResultDto<GetProductsForAdminDto> Execute(RequestGetProductsForAdmin requestGetProductsForAdmin);
}