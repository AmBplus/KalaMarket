using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductForAdmin;

public interface IGetProductForAdminService
{
    public ResultDto<GetProductForAdminDto> Execute(RequestGetProductForAdmin requestGetProductsForAdmin);
}