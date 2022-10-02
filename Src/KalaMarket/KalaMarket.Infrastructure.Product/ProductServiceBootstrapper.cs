#region using

using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Implement;
using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Products.ProductAggFacade;
using KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Implement;
using KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Interfaces;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
#endregion /using

namespace KalaMarket.Infrastructure.Product;

public static class ProductServiceBootstrapper
{
    public static void ConfigureProductServices(this IServiceCollection services)
    {

        // Add Category Services      
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        // Add Brand Services
        services.AddScoped<IBrandFacade, BrandFacade>();
        // Add Product Facade Service
        services.AddScoped<IProductFacadeService, ProductFacadeService>();
        // Add ProductAgg Facade Service
        services.AddScoped<IProductAggFacadeService, ProductAggFacadeService>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        // Add Mapster Map Config
        typeAdapterConfig.Scan(typeof(ProductAggFacadeService).Assembly);

    }
}