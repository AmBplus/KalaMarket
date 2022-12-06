using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.EditCategory;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.RemoveCategory;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.CommandFacade;

public interface ICategoryCommandFacade
{
    IEditCategoryService EditCategoryService { get; }
    IRemoveCategoryService RemoveCategoryService { get; }
    IAddCategoryService AddCategoryService { get; }
}