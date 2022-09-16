using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.ProductService.Commands.AddProduct;

public interface IAddProductService
{
    ResultDto Execute(RequestAddProductDto product);
}