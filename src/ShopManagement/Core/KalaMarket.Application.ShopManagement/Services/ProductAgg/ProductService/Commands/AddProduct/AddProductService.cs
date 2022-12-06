using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Utility;
using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Commands.AddProduct;

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
        var result = new ResultDto();

        var product = GetProduct(requestAddProduct, result);
        Context.Products.Add(product);
        Context.HandleSaveChange(result, Logger);

        return result;
    }

    private Product GetProduct(RequestAddProductDto requestAddProduct,
        ResultDto result)
    {
        var product =
            new Product(requestAddProduct.Name, requestAddProduct.Description,
                requestAddProduct.Name.Slugify(),
                requestAddProduct.CategoryId,
                requestAddProduct.Inventory, requestAddProduct.Displayed,
                requestAddProduct.Price, requestAddProduct.BrandId);
        var features = requestAddProduct.Features.Select(x => new ProductFeatures(product.Id, x.KeyName, x.KeyValue))
            .ToList();
        var images = requestAddProduct.ImagesSrc
            .Select(imagePath => new ProductImages(product.Id, product.Name, imagePath)).ToList();
        product.SetFeature(features);
        product.SetImages(images);
        return product;
    }
}