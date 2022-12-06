using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Command.Active;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Command.Add;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Interface;

public interface IBrandCmdFacade
{
    IAddBrandService AddBrandService { get; }
    IChangeBrandActivationService ChangeActivation { get; }
}