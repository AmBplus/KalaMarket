using KalaMarket.Application.Services.Product.CategoryServices.Commands.AddNewCategory;
using KalaMarket.Application.Services.Product.CategoryServices.Commands.EditCategory;
using KalaMarket.Application.Services.Product.CategoryServices.Commands.RemoveCategory;

namespace KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.CommandFacade;

public interface ICategoryCommandFacade
{
    IEditCategoryService EditCategoryService { get; }
    IRemoveCategoryService RemoveCategoryService { get; }
    IAddCategoryService AddCategoryService { get; }
}