using KalaMarket.Application.Product.Services.Products.BrandService.Command.Active;
using KalaMarket.Application.Product.Services.Products.BrandService.Command.Add;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;

public interface IBrandCmdFacade
{
    IAddBrandService AddBrandService { get; }
    IChangeBrandActivationService ChangeActivation { get; }
}