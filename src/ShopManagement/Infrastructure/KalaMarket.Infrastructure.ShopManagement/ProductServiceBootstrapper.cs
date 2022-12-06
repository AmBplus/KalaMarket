#region using

using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Implement;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.FacadePattern.Implement;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.FacadePattern.Interfaces;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

#endregion /using

namespace KalaMarket.Infrastructure.ShopManagement;

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