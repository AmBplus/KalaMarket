using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetDetailProductForAdmin;

public interface IGetDetailProductForAdminService
{
    ResultDto<ProductDetailForAdmindto> Execute(RequestGetDetailForAdmin request);
}


