using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Implement;

internal class ProductQueryFacade : IProductQueryFacade
{
    public ProductQueryFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private  IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
}