using KalaMarket.Application.Product.Services.Products.ProductService.Commands.AddProduct;

namespace KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Interfaces;

public interface IProductCommandFacade
{
    IAddProductService Add { get; }
}