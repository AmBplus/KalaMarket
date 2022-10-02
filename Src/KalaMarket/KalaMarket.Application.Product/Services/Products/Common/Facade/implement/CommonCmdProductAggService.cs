using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Products.Common.Facade.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Products.Common.Facade.implement;

public class CommonCmdProductAggService : ICommonCmdProductAggService
{
    public IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }

    public CommonCmdProductAggService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
}