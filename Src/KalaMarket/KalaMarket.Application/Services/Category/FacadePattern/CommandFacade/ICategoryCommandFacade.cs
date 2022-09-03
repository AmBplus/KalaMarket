using KalaMarket.Application.Services.Category.Commands.AddNewCategory;
using KalaMarket.Application.Services.Category.Commands.EditCategory;
using KalaMarket.Application.Services.Category.Commands.RemoveCategory;

namespace KalaMarket.Application.Services.Category.FacadePattern.CommandFacade;

public interface ICategoryCommandFacade
{
    IEditCategoryService EditCategoryService { get; }
    IRemoveCategoryService RemoveCategoryService { get; }
    IAddCategoryService AddCategoryService { get; }
}