#region Using

using KalaMarket.Application.User.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.User.Services.Users.Commands.EditUser;
using KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Implement;
using KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.User.Services.Users.FacadePattern;
using KalaMarket.Application.User.Services.Users.Queries.GetRole;
using KalaMarket.Application.User.Services.Users.Queries.GetRoles.Implement;
using KalaMarket.Application.User.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Implement;
using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace KalaMarket.Infrastructure.User;

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