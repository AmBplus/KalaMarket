using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Command.Active;

public interface IChangeBrandActivationService
{
    ResultDto Execute(RequestChangeActivation requestChangeActivation);
}