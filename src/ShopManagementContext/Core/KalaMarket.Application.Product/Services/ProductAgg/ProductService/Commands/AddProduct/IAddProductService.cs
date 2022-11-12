using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.Commands.AddProduct;

public interface IAddProductService
{
    ResultDto Execute(RequestAddProductDto product);
}