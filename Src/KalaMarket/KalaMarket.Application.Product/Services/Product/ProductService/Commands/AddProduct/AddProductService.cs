using _0_Framework.Application;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Utility;
using KalaMarket.Domain.Entities.ProductAgg;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Commands.AddProduct;

public class AddProductService : IAddProductService
{
    public AddProductService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ResultDto Execute(RequestAddProductDto requestAddProduct)
    {
        ResultDto result = new ResultDto();
            // Create Product 
        
            Domain.Entities.ProductAgg.Product product = AddProduct(requestAddProduct, result);
            Context.Products.Add(product);
            Context.HandleSaveChange(result, Logger);
            // Return result 
            return result;
    }

    private Domain.Entities.ProductAgg.Product AddProduct(RequestAddProductDto requestAddProduct,
        ResultDto result)
    {
        Domain.Entities.ProductAgg.Product product =
            new Domain.Entities.ProductAgg.Product(requestAddProduct.Name, requestAddProduct.Description,
                requestAddProduct.Name.Slugify(),
                requestAddProduct.CategoryId,
                requestAddProduct.Inventory, requestAddProduct.Displayed, 
                requestAddProduct.Price, requestAddProduct.BrandId);
       var features = requestAddProduct.Features.Select(x => new ProductFeatures(product.Id, x.KeyName, x.KeyValue)).ToList();
       var images = requestAddProduct.ImagesSrc.Select(imagePath => new ProductImages(product.Id, product.Name, imagePath)).ToList();
       product.SetFeature(features);
       product.SetImages(images);
        return product;
    }
}