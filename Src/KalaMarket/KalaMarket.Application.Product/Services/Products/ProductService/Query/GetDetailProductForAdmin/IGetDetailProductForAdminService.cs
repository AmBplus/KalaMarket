using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.ProductService.Query.GetDetailProductForAdmin;

public interface IGetDetailProductForAdminService
{
    ResultDto<ProductDetailForAdmindto> Execute(RequestGetDetailForAdmin request);
}


