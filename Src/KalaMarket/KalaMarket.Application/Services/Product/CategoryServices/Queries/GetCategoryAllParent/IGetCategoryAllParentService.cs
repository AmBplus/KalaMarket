using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryAllParent;

public interface IGetCategoryAllParentService
{
    ResultDto<GetCategoryAllParentServiceDto> Execute(long categoryId);
}