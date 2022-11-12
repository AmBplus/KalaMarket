#region Using

using KalaMarket.Application.Agg.Services;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Persistence.Context;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace KalaMarket.Infrastructure;

public static class ServiceBootstrapper
{
    public static void ConfigureServices(this IServiceCollection services, string connection)
    {
        #region DbService

        services.AddDbContext<IKalaMarketContext, KalaMarketContext>(option =>
        {
            SqlServerDbContextOptionsExtensions.UseSqlServer(option, connection);
        });

        #endregion /DbService

        // Custom LogManger
        services.AddSingleton<ILoggerManger, LoggerManger>();
        services.AddSingleton(typeof(ILoggerManger<>), typeof(LoggerManger<>));
        // Add Whole KalaMarket Services
        services.AddScoped<IKalaMarketAggServices, KalaMarketAggServices>();
    }
}