using KalaMarket.Application.Services.Category.Queries.GetCategory;
using KalaMarket.Application.Services.Category.Queries.GetCategoryWithChild;
using KalaMarket.Application.Services.Category.Queries.GetCategoryWithParent;
using KalaMarket.Application.Services.Category.Queries.GetCategoryWithParentChild;

namespace KalaMarket.Application.Services.Category.FacadePattern.QueryFacade;

public interface ICategoryQueryFacade
{
    IGetCategoryService GetCategoryService { get; }
    IGetCategoryChildService GetCategoryChildService { get; }
    IGetCategoryWithParentChildService GetCategoryWithParentChildService { get; }
    IGetCategoryParentService GetCategoryParentService { get; }
}