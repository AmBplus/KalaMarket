using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Category.Commands.AddNewCategory;

public interface IAddCategoryService
{
    ResultDto Execute(RequestAddNewCategoryDto request);
}