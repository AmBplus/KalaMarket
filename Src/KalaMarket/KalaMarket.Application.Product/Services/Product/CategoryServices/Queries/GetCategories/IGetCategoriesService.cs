using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategories;

public interface IGetCategoriesService
{
    ResultDto<GetCategoriesServiceDto> Execute(RequestGetCategoriesDto request);
}