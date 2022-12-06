using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductForAdmin;

public interface IGetProductForAdminService
{
    public ResultDto<GetProductForAdminDto> Execute(RequestGetProductForAdmin requestGetProductsForAdmin);
}