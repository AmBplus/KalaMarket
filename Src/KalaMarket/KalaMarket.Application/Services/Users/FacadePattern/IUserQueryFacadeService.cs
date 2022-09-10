using KalaMarket.Application.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Services.Users.Commands.EditUser;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;

namespace KalaMarket.Application.Services.Users.FacadePattern;

public interface IUserQueryFacadeService
{
    IGetUsersService GetUsersService { get; }
    IGetRemovedUsersService GetRemovedUsersService { get; }
    IGetRolesService GetRolesService { get; }
    IGetRoleService GetRoleService { get; }
    IGetUserWithRolesService GetUserWithRolesService { get; }
}