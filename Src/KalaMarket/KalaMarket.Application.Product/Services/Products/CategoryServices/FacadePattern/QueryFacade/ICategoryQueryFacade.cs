using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategories;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategory;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategoryWithAllParent;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategoryWithChild;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategoryWithParent;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategoryWithParentChild;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.QueryFacade;

public interface ICategoryQueryFacade
{
    IGetCategoryService GetCategory { get; }
    IGetCategoryChildService GetChild { get; }
    IGetCategoryWithParentChildService GetParentAndChild { get; }
    IGetCategoryParentService GetParent { get; }
    IGetCategoryWithAllParentService GetAllParent { get; }
    IGetCategoriesService GetCategories { get; }
}