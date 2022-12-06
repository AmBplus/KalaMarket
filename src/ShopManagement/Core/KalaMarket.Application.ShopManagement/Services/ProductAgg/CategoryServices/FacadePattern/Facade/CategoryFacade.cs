using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.CommandFacade;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.QueryFacade;
using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.Facade;

public class CategoryFacade : ICategoryFacade
{
    #region Constructor

    public CategoryFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion

    #region Fields

    private ICategoryCommandFacade _categoryCommand;
    private ICategoryQueryFacade _categoryQuery;

    #endregion

    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ICategoryCommandFacade CategoryCommand => _categoryCommand = new CategoryCommandFacade(Context);

    public ICategoryQueryFacade CategoryQuery => _categoryQuery = new CategoryQueryFacade(Context);

    #endregion
}