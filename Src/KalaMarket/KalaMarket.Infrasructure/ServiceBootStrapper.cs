#region Using

using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using KalaMarket.Shared;

#endregion

namespace KalaMarket.Infrastructure;

public static class ServiceBootstrapper
{
    public static void ConfigureServices(this IServiceCollection services , string connection )
    {
        #region DbService
        services.AddDbContext<IKalaMarketContext, KalaMarketContext>(option =>
        {
            option.UseSqlServer(connection);
        });
        #endregion /DbService
        // Custom LogManger
        services.AddSingleton<ILoggerManger, LoggerManger>();
        services.AddSingleton(typeof(ILoggerManger<>), typeof(LoggerManger<>));
    }
}