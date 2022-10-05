using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Query.GetAll;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Implement;

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