using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductsForAdmin;

public interface IGetProductsForAdminService
{
    public ResultDto<GetProductsForAdminDto> Execute(RequestGetProductsForAdmin requestGetProductsForAdmin);
}