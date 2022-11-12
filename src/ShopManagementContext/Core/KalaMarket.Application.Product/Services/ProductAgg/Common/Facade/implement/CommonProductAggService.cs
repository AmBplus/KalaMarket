using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.ProductAgg.Common.Facade.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.ProductAgg.Common.Facade.implement;

public class CommonProductAggService : ICommonProductAggService
{
    private ICommonQueryProductAggService? _cmd;
    private ICommonQueryProductAggService? _query;

    public CommonProductAggService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #region Properties

    public IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }

    public ICommonQueryProductAggService Query => _query ??= new CommonQueryProductAggService(Context, Logger);

    public ICommonQueryProductAggService Cmd => _cmd ??= new CommonQueryProductAggService(Context, Logger);

    #endregion /Properties
}