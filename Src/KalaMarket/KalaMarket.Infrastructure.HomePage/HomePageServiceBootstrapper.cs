#region using

using KalaMarket.Application.HomePage.HomePage.Facade;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

#endregion /using

namespace KalaMarket.Infrastructure.HomePage;

public static class HomePageServiceBootstrapper
{
    public static void ConfigureHomePageServices(this IServiceCollection services)
    {
        services.AddScoped<IHomePageAggFacadeService, HomePageAggFacadeService>();
        var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
        // Add Mapster Map Config
        typeAdapterConfig.Scan(typeof(IHomePageAggFacadeService).Assembly);
        services.AddScoped<IHomePageAggFacadeService, HomePageAggFacadeService>();
    }
}