#region Using

using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Implement;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace KalaMarket.Infrastructure.Product;

public static class ProductServiceBootstrapper
{
    public static void ConfigureProductServices(this IServiceCollection services )
    {

        // Add Category Services      
        services.AddScoped<ICategoryFacade, CategoryFacade>();
        // Add Brand Services
        services.AddScoped<IBrandFacade, BrandFacade>();
    }
}