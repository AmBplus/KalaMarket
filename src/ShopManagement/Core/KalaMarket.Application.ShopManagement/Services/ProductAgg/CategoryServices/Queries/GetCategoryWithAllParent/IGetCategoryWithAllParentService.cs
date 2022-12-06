using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithAllParent;

public interface IGetCategoryWithAllParentService
{
    ResultDto<GetCategoryWithAllParentServiceDto> Execute(long categoryId);
}