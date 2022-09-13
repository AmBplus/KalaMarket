using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategories;

public interface IGetCategoriesService
{
    ResultDto<GetCategoriesServiceDto> Execute(byte? type = null);
}