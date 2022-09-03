using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Category.Commands.EditCategory;

public interface IEditCategoryService
{
    ResultDto Execute(RequestEditCategoryDto request);
}