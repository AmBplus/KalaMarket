using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithAllParent;

public interface IGetCategoryWithAllParentService
{
    ResultDto<GetCategoryWithAllParentServiceDto> Execute(long categoryId);
}