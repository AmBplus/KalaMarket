using KalaMarket.Application.Identity.Services.Users.Queries.GetRole;
using KalaMarket.Application.Identity.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;

namespace KalaMarket.Application.Identity.Services.Users.FacadePattern;

public interface IUserQueryFacadeService
{
    IGetUsersService GetUsersService { get; }
    IGetRemovedUsersService GetRemovedUsersService { get; }
    IGetRolesService GetRolesService { get; }
    IGetRoleService GetRoleService { get; }
    IGetUserWithRolesService GetUserWithRolesService { get; }
}