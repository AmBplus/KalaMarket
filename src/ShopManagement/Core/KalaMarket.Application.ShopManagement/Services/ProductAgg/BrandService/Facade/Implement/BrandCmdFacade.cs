using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Command.Active;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Command.Add;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Implement;

public class BrandCmdFacade : IBrandCmdFacade
{
    private IAddBrandService? _addBrandService;
    private IChangeBrandActivationService? _changeActivation;

    public BrandCmdFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private ILoggerManger Logger { get; }
    private IKalaMarketContext Context { get; }

    public IAddBrandService AddBrandService => _addBrandService ?? new AddBrandService(Logger, Context);

    public IChangeBrandActivationService ChangeActivation =>
        _changeActivation ?? new ChangeBrandActivationService(Logger, Context);
}