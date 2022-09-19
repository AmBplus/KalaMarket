using KalaMarket.Application.User.Services.Users.Queries.GetRole;
using KalaMarket.Application.User.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Interfaces;

namespace KalaMarket.Application.User.Services.Users.FacadePattern;

public interface IUserQueryFacadeService
{
    IGetUsersService GetUsersService { get; }
    IGetRemovedUsersService GetRemovedUsersService { get; }
    IGetRolesService GetRolesService { get; }
    IGetRoleService GetRoleService { get; }
    IGetUserWithRolesService GetUserWithRolesService { get; }
}