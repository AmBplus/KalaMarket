using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Commands.AddProduct;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.FacadePattern.Interfaces;

public interface IProductCommandFacade
{
    IAddProductService Add { get; }
}