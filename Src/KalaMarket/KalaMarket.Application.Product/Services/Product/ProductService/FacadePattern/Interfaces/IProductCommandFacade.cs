using KalaMarket.Application.Product.Services.Product.ProductService.Commands.AddProduct;

namespace KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;

public interface IProductCommandFacade
{
    IAddProductService Add { get; }
}