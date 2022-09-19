using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.CategoryServices.Commands.EditCategory;

public interface IEditCategoryService
{
    ResultDto Execute(RequestEditCategoryDto request);
}