﻿using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Category.FacadePattern.CommandFacade;
using KalaMarket.Application.Services.Category.FacadePattern.QueryFacade;

namespace KalaMarket.Application.Services.Category.FacadePattern.Facade;

public class CategoryFacade : ICategoryFacade
{
    #region Fields

    private ICategoryCommandFacade _categoryCommand;
    private ICategoryQueryFacade _categoryQuery;

    #endregion

    #region Constructor

    public CategoryFacade(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion

    #region Properties

    private IKalaMarketContext Context { get; }

    public ICategoryCommandFacade CategoryCommand => _categoryCommand = new CategoryCommandFacade(Context);

    public ICategoryQueryFacade CategoryQuery => _categoryQuery = new CategoryQueryFacade(Context);

    #endregion
}