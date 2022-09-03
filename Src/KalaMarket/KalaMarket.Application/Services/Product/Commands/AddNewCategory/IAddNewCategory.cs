using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.Commands.AddNewCategory;

public interface IAddNewCategory
{
    ResultDto Execute(RequestAddNewCategoryDto request);
}