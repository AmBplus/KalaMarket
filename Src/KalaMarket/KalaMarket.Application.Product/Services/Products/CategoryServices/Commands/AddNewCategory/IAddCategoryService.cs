using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.AddNewCategory;

public interface IAddCategoryService
{
    ResultDto Execute(RequestAddNewCategoryDto request);
}