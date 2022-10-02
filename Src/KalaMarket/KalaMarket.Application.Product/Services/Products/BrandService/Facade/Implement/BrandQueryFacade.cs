using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Products.BrandService.Query.GetAll;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Facade.Implement;

public class BrandQueryFacade : IBrandQueryFacade
{
    public BrandQueryFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    private IGetAllBrandService? _getAll { get; set; }

    public IGetAllBrandService GetAll => _getAll ?? new GetAllBrandService(Context, Logger);
}