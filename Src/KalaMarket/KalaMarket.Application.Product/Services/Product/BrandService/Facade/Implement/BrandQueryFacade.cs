using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.BrandService.Facade.Implement;

public class BrandQueryFacade : IBrandQueryFacade
{
    public BrandQueryFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
}