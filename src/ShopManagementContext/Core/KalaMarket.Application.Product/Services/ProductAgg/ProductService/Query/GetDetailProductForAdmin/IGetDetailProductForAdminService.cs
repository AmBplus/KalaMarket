using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetDetailProductForAdmin;

public interface IGetDetailProductForAdminService
{
    ResultDto<ProductDetailForAdmindto> Execute(RequestGetDetailForAdmin request);
}