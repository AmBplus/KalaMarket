using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Products.Common.Facade.Interfaces;
using KalaMarket.Application.Product.Services.Products.Common.Query.GetCategorySite;
using KalaMarket.Application.Product.Services.Products.Common.Query.GetMenuItemService;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Products.Common.Facade.implement;

public class CommonQueryProductAggService : ICommonQueryProductAggService
{

    #region Fields
    private IGetMenuItemService? _getMenuItems;
    private IGetCategorySiteService? _getCategoriesSite;

    #endregion /Fields

    public CommonQueryProductAggService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #region Properties
    public IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }
    public IGetMenuItemService GetMenuItems => _getMenuItems ??= new GetMenuItemService(Context, Logger);

    public IGetCategorySiteService GetCategoriesSite => _getCategoriesSite ??= new GetCategorySiteService(Context, Logger);

    #endregion /Properties
}