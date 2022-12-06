using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Facade.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Facade.implement;

public class CommonCmdProductAggService : ICommonCmdProductAggService
{
    public CommonCmdProductAggService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    public IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }
}