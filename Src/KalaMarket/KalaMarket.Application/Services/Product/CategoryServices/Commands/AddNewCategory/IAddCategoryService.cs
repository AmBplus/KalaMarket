using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.CategoryServices.Commands.AddNewCategory;

public interface IAddCategoryService
{
    ResultDto Execute(RequestAddNewCategoryDto request);
}