using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategories;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategory;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithAllParent;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithChild;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithParent;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithParentChild;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.QueryFacade;

public interface ICategoryQueryFacade
{
    IGetCategoryService GetCategory { get; }
    IGetCategoryChildService GetChild { get; }
    IGetCategoryWithParentChildService GetParentAndChild { get; }
    IGetCategoryParentService GetParent { get; }
    IGetCategoryWithAllParentService GetAllParent { get; }
    IGetCategoriesService GetCategories { get; }
}