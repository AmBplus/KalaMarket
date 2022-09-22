using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.BrandService.Command.Add;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.BrandService.Facade.Implement;

public class BrandCmdFacade : IBrandCmdFacade
{
    public BrandCmdFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    private ILoggerManger Logger { get;}
    private IKalaMarketContext Context { get;}
    private IAddBrandService? _addBrandService;

    public IAddBrandService AddBrandService => _addBrandService?? new AddBrandService(Logger,Context);
}