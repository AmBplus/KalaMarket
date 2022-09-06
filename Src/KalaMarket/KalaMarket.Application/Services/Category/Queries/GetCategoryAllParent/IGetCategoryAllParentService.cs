using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Category.Queries.GetCategoryAllParent;

public interface IGetCategoryAllParentService
{
    ResultDto<GetCategoryAllParentServiceDto> Execute(long categoryId);
}