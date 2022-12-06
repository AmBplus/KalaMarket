using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Implement;

public class BrandFacade : IBrandFacade
{
    private IBrandCmdFacade? _brandCmd;
    private IBrandQueryFacade? _brandQuery;

    public BrandFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public IBrandQueryFacade BrandQuery => _brandQuery ?? new BrandQueryFacade(Context, Logger);

    public IBrandCmdFacade brandCmd => _brandCmd = new BrandCmdFacade(Context, Logger);
}