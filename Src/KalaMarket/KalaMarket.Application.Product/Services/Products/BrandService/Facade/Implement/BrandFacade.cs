using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Facade.Implement;

public class BrandFacade : IBrandFacade
{
    public BrandFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    private IBrandQueryFacade? _brandQuery;
    private IBrandCmdFacade? _brandCmd;

    public IBrandQueryFacade BrandQuery => _brandQuery ?? new BrandQueryFacade(Context, Logger);

    public IBrandCmdFacade brandCmd => _brandCmd = new BrandCmdFacade(Context, Logger);
}