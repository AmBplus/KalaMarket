using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.Common.Facade.Interfaces;
using KalaMarket.Application.Product.Services.Product.Common.Query.GetMenuItemService;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.Common.Facade.implement;

public class CommonQueryProductAggService : ICommonQueryProductAggService
{
    
    #region Fields
    private IGetMenuItemService? _getMenuItems;
    #endregion /Fields

    public CommonQueryProductAggService(IKalaMarketContext context , ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #region Properties
    public IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }
    public IGetMenuItemService GetMenuItems => _getMenuItems ?? new GetMenuItemService(Context,Logger);
    #endregion /Properties
}