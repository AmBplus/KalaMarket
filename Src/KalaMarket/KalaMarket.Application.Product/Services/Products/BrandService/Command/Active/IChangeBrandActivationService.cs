using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Command.Active;

public interface IChangeBrandActivationService
{
    ResultDto Execute(RequestChangeActivation requestChangeActivation);
}