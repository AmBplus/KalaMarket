using KalaMarket.Application.Product.Services.Product.BrandService.Command.Active;
using KalaMarket.Application.Product.Services.Product.BrandService.Command.Add;

namespace KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;

public interface IBrandCmdFacade
{
    IAddBrandService AddBrandService { get; }
    IChangeBrandActivationService ChangeActivation{ get; }
}