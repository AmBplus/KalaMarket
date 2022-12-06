using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetDetailProductForAdmin;

public interface IGetDetailProductForAdminService
{
    ResultDto<ProductDetailForAdmindto> Execute(RequestGetDetailForAdmin request);
}