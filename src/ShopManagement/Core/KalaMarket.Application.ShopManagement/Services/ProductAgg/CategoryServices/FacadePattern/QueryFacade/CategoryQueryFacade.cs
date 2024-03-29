﻿using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategories;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategory;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithAllParent;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithChild;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithParent;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithParentChild;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.QueryFacade;

public class CategoryQueryFacade : ICategoryQueryFacade
{
    #region Constructor

    public CategoryQueryFacade(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Constructor

    #region Fields

    private IGetCategoryService? _getCategoryService;
    private IGetCategoryChildService? _getCategoryWithChildService;
    private IGetCategoryWithParentChildService? _getCategoryWithParentChildService;
    private IGetCategoryParentService? _getCategoryWithParentService;
    private IGetCategoryWithAllParentService? _getAllParent;
    private IGetCategoriesService? _getCategories;

    #endregion /Fields

    #region Properties

    private IKalaMarketContext Context { get; }

    public IGetCategoryService GetCategory => _getCategoryService ??= new GetCategoryService(Context);

    public IGetCategoryChildService GetChild =>
        _getCategoryWithChildService ??= new GetCategoryChildService(Context);

    public IGetCategoryWithParentChildService GetParentAndChild =>
        _getCategoryWithParentChildService ??= new GetCategoryWithParentChildService(Context);

    public IGetCategoryParentService GetParent =>
        _getCategoryWithParentService ??= new GetCategoryParentService(Context);

    public IGetCategoryWithAllParentService GetAllParent => _getAllParent ??= new GetCategoryAllParentService(Context);

    public IGetCategoriesService GetCategories => _getCategories ??= new GetCategoriesService(Context);

    #endregion /Properties
}