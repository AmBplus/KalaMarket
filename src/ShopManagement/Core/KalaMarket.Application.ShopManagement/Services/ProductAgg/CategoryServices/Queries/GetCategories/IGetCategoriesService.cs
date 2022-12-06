using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategories;

public interface IGetCategoriesService
{
    ResultDto<GetCategoriesServiceDto> Execute(RequestGetCategoriesDto request);
}