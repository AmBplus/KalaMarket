using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategory;

public interface IGetCategoryService
{

    ResultDto<GetCategoryServiceDto> Execute(long id);
}