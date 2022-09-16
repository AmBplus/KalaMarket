using System.Collections;
using KalaMarket.Domain.Entities.ProductAgg;
using KalaMarket.Shared.Dto;
namespace KalaMarket.Application.Services.Product.ProductService.Commands.AddProduct;

public class AddProductService : IAddProductService
{
    public ResultDto Execute(RequestAddProductDto requestAddProduct)
    {
        ResultDto result = new ResultDto();
            // Create Product 
            ICollection<ProductFeatures> productFeatures = new List<ProductFeatures>();
            ICollection<ProductImages> productImages = new List<ProductImages>();
            Domain.Entities.ProductAgg.Product product = AddProduct(requestAddProduct, productFeatures,productImages, result);

        // Return result 
        return result;
    }

    private Domain.Entities.ProductAgg.Product AddProduct(RequestAddProductDto requestAddProduct,
        ICollection<ProductFeatures> productFeatures,ICollection<ProductImages> productImages,
        ResultDto result)
    {
        Domain.Entities.ProductAgg.Product product = 
            new Domain.Entities.ProductAgg.Product(requestAddProduct.Name,requestAddProduct.Description,requestAddProduct.CategoryId,
                requestAddProduct.Inventory,requestAddProduct.Displayed,requestAddProduct.Price,requestAddProduct.BrandId,productFeatures,
                productImages)
        {
            
        };
        return product;
    }
}