#region Using

using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace KalaMarket.Infrastructure.Product;

public static class ProductServiceBootstrapper
{
    public static void ConfigureProductServices(this IServiceCollection services )
    {
        
        #region Category Facade Service

        services.AddScoped<ICategoryFacade, CategoryFacade>();

        #endregion /Category Facade Service

    }
}