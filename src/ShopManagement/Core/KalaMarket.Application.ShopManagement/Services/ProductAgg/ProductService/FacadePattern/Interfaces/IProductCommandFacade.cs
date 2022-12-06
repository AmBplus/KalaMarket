using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Commands.AddProduct;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.FacadePattern.Interfaces;

public interface IProductCommandFacade
{
    IAddProductService Add { get; }
}