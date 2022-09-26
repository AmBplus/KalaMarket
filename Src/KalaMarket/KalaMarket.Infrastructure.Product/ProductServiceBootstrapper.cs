#region using
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Implement;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.ProductAggFacade;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Implement;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;
using Microsoft.Extensions.DependencyInjection;
#endregion /using

namespace KalaMarket.Infrastructure.Product;

public static class ProductServiceBootstrapper
{
    public static void ConfigureProductServices(this IServiceCollection services )
    {

        // Add Category Services      
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        // Add Brand Services
        services.AddScoped<IBrandFacade, BrandFacade>();
        // Add Product Facade Service
        services.AddScoped<IProductFacadeService, ProductFacadeService>();
        // Add ProductAgg Facade Service
        services.AddScoped<IProductAggFacadeService, ProductAggFacadeService>();
    }
}