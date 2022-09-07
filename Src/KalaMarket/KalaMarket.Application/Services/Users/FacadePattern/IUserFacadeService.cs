using KalaMarket.Application.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Services.Users.Commands.EditUser;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;

namespace KalaMarket.Application.Services.Users.FacadePattern;

public interface IUserFacadeService
{
    IGetUsersService GetUsersService { get; }
    IRegisterUserService RegisterUserService { get; }
    IGetRemovedUsersService GetRemovedUsersService { get; }
    IGetRolesService GetRolesService { get; }
    IGetRoleService GetRoleService { get; }
    IChangeActivationUserService ChangeActivationUserService { get; }
    IChangeRemoveRoleService ChangeRemoveRoleService { get; }
    IChangeRemoveUserService ChangeRemoveUserService { get; }
    IEditUserService EditUserService { get; }
    IGetUserWithRolesService GetUserWithRolesService { get; }
}