#region Using

using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Implement;
using KalaMarket.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Implement;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Services.Users.Commands.EditUser;
using KalaMarket.Application.Services.Users.FacadePattern;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Shared;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Implement;

#endregion

namespace KalaMarket.Infrastructure;

public static class ServiceBootStrapper
{
    public static void ConfigureServices(this IServiceCollection services , string connection )
    {
        #region DbService
        services.AddDbContext<IKalaMarketContext, KalaMarketContext>(option =>
        {
            option.UseSqlServer(connection);
        });
        #endregion /DbService

        #region UserServices

        services.AddScoped<IGetUsersService, GetUsersService>();
        services.AddScoped<IRegisterUserService, RegisterUserService>();
        services.AddScoped<IGetRemovedUsersService, GetRemovedUsersService>();
        services.AddScoped<IGetRolesService, GetRolesService>();
        services.AddScoped<IGetRoleService, GetRoleService>();
        services.AddScoped<IChangeActivationUserService, ChangeActivationUserService>();
        services.AddScoped<IChangeRemoveRoleService, ChangeRemoveRoleService>();
        services.AddScoped<IChangeRemoveUserService, ChangeRemoveUserService>();
        services.AddScoped<IEditUserService, EditUserService>();
        services.AddScoped<IGetUserWithRolesService, GetUserWithRolesService>();

        #endregion /UserServices

        #region User Facade Service
        services.AddScoped<IUserFacadeService, UserFacadeService>();
        #endregion /User Facade Service

        #region Category Facade Service

        services.AddScoped<ICategoryFacade, CategoryFacade>();

        #endregion /Category Facade Service


        // Custom LogManger
        services.AddSingleton<ILoggerManger, LoggerManger>();
        services.AddSingleton(typeof(ILoggerManger<>), typeof(LoggerManger<>));
    }
}