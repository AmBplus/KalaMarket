using KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.AddNewCategory;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.EditCategory;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.RemoveCategory;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.CommandFacade;

public interface ICategoryCommandFacade
{
    IEditCategoryService EditCategoryService { get; }
    IRemoveCategoryService RemoveCategoryService { get; }
    IAddCategoryService AddCategoryService { get; }
}