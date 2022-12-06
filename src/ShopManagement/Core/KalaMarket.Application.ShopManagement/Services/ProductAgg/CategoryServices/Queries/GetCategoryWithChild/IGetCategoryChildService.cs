using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithChild;

public interface IGetCategoryChildService
{
    ResultDto<GetCategoryChildServiceDto> Execute(long id);
}