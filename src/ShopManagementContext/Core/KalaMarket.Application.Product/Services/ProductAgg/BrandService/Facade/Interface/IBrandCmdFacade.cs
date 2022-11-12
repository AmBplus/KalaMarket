using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Command.Active;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Command.Add;

namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Interface;

public interface IBrandCmdFacade
{
    IAddBrandService AddBrandService { get; }
    IChangeBrandActivationService ChangeActivation { get; }
}