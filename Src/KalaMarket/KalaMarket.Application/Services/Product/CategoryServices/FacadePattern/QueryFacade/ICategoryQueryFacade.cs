using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategory;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryAllParent;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithChild;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithParent;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithParentChild;

namespace KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.QueryFacade;

 public interface ICategoryQueryFacade
{
    IGetCategoryService GetCategory { get; }
    IGetCategoryChildService GetChild { get; }
    IGetCategoryWithParentChildService GetParentAndChild { get; }
    IGetCategoryParentService GetParent { get; }
    IGetCategoryAllParentService GetAllParent { get; }
}