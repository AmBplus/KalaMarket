using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;
using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.EditCategory;
using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.RemoveCategory;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.CommandFacade;

public interface ICategoryCommandFacade
{
    IEditCategoryService EditCategoryService { get; }
    IRemoveCategoryService RemoveCategoryService { get; }
    IAddCategoryService AddCategoryService { get; }
}