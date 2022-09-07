using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Services.Users.Commands.EditUser;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Implement;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Implement;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Implement;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;

namespace KalaMarket.Application.Services.Users.FacadePattern;

public class UserFacadeService : IUserFacadeService
{
    public UserFacadeService(IKalaMarketContext context)
    {
        Context = context;
    }
    private IGetUsersService? _getUsersService;
    private IRegisterUserService? _registerUserService;
    private IGetRemovedUsersService? _getRemovedUsersService;
    private IGetRolesService? _getRolesService;
    private IGetRoleService? _getRoleService;
    private IChangeActivationUserService? _changeActivationUserService;
    private IChangeRemoveRoleService? _changeRemoveRoleService;
    private IChangeRemoveUserService? _changeRemoveUserService;
    private IEditUserService? _editUserService;
    private IGetUserWithRolesService? _getUserWithRolesService;
    private IKalaMarketContext? Context;
    public IGetUsersService GetUsersService => _getUsersService ??= new GetUsersService(Context);

    public IRegisterUserService RegisterUserService => _registerUserService ??= new RegisterUserService(Context);

    public IGetRemovedUsersService GetRemovedUsersService =>
        _getRemovedUsersService ??= new GetRemovedUsersService(Context);

    public IGetRolesService GetRolesService => _getRolesService ??= new GetRolesService(Context);

    public IGetRoleService GetRoleService => _getRoleService ??= new GetRoleService(Context);

    public IChangeActivationUserService ChangeActivationUserService => _changeActivationUserService ??= new ChangeActivationUserService(Context);

    public IChangeRemoveRoleService ChangeRemoveRoleService => _changeRemoveRoleService ??= new ChangeRemoveRoleService(Context);

    public IChangeRemoveUserService ChangeRemoveUserService => _changeRemoveUserService ??= new ChangeRemoveUserService(Context);

    public IEditUserService EditUserService => _editUserService ??= new EditUserService(Context);

    public IGetUserWithRolesService GetUserWithRolesService => _getUserWithRolesService ??= new GetUserWithRolesService(Context);
}