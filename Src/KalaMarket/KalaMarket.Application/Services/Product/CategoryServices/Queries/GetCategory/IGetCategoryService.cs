using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategory;

public interface IGetCategoryService
{

    ResultDto<GetCategoryServiceDto> Execute(long id);
}