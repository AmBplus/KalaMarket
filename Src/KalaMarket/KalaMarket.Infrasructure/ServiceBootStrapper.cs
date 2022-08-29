using System.Runtime.CompilerServices;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Commands.RegisterUser;
using KalaMarket.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Implement;
using KalaMarket.Application.Services.Users.Queries.GetRole.Interface;
using KalaMarket.Application.Services.Users.Queries.GetRole.Implement;

namespace KalaMarket.Infrastructure;

public static class ServiceBootStrapper
{
    public static void ConfigureServices(this IServiceCollection services , string connection )
    {
        services.AddDbContext<IKalaMarketContext, KalaMarketContext>(option =>
        {
            option.UseSqlServer(connection);
        });
        services.AddScoped<IGetUsersService, GetUsersService>();
        services.AddScoped<IRegisterUserService, RegisterUserService>();
        services.AddScoped<IGetRemovedUsersService, GetRemovedUsersService>();
        services.AddScoped<IGetRolesService, GetRolesService>();
    }
}