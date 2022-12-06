using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategory;

public interface IGetCategoryService
{
    ResultDto<GetCategoryServiceDto> Execute(long id);
}