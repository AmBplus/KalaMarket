using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.ProductService.Commands.AddProduct;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Implement;

internal class ProductCommandFacade : IProductCommandFacade
{
    public ProductCommandFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get;  }
    private ILoggerManger Logger { get; }
    private IAddProductService? _add;

    public IAddProductService Add => _add ?? new AddProductService(Context,Logger);
}