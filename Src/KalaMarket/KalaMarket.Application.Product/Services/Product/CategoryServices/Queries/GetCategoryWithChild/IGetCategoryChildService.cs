using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategoryWithChild;

public interface IGetCategoryChildService
{
    ResultDto<GetCategoryChildServiceDto> Execute(long id);
}