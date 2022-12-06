using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Facade.Interfaces;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetCategorySite;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetMenuItemService;
using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Facade.implement;

public class CommonQueryProductAggService : ICommonQueryProductAggService
{
    public CommonQueryProductAggService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #region Fields

    private IGetMenuItemService? _getMenuItems;
    private IGetCategorySiteService? _getCategoriesSite;

    #endregion /Fields

    #region Properties

    public IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }
    public IGetMenuItemService GetMenuItems => _getMenuItems ??= new GetMenuItemService(Context, Logger);

    public IGetCategorySiteService GetCategoriesSite =>
        _getCategoriesSite ??= new GetCategorySiteService(Context, Logger);

    #endregion /Properties
}