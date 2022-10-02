using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.CommandFacade;
using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.QueryFacade;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.Facade;

public class CategoryFacade : ICategoryFacade
{
    #region Fields

    private ICategoryCommandFacade _categoryCommand;
    private ICategoryQueryFacade _categoryQuery;

    #endregion

    #region Constructor

    public CategoryFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion

    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ICategoryCommandFacade CategoryCommand => _categoryCommand = new CategoryCommandFacade(Context);

    public ICategoryQueryFacade CategoryQuery => _categoryQuery = new CategoryQueryFacade(Context);

    #endregion
}