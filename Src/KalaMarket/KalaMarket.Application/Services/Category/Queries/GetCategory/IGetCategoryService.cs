using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Category.Queries.GetCategory;

public interface IGetCategoryService
{

    ResultDto<GetCategoryServiceDto> Execute(long id);
}