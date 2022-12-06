#region Using

#endregion

using KalaMarket.Application.Identity.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Identity.Services.Users.Commands.EditUser;
using KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Implement;
using KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Identity.Services.Users.FacadePattern;
using KalaMarket.Application.Identity.Services.Users.Queries.GetRole;
using KalaMarket.Application.Identity.Services.Users.Queries.GetRoles.Implement;
using KalaMarket.Application.Identity.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Implement;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace KalaMarket.Infrastructure.Identity;

public static class UserServiceBootstrapper
{
    public static void ConfigureUserServices(this IServiceCollection services)
    {
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

        services.AddScoped<IUserAggFacadeService, UserAggFacadeService>();

        #endregion /User Facade Service
    }
}