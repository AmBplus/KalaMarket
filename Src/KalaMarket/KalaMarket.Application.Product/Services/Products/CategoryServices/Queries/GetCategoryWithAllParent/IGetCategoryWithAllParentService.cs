using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategoryWithAllParent;

public interface IGetCategoryWithAllParentService
{
    ResultDto<GetCategoryWithAllParentServiceDto> Execute(long categoryId);
}