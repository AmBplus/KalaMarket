using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Implement;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Implement;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Services.Users.FacadePattern;

public class UserQueryFacadeService : IUserQueryFacadeService
{
    #region Constructor
    public UserQueryFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    } 
    #endregion
   
    #region Fields
    private readonly IKalaMarketContext Context;
    private readonly ILoggerManger Logger;
    private IGetUsersService? _getUsersService;
    private IGetRemovedUsersService? _getRemovedUsersService;
    private IGetRolesService? _getRolesService;
    private IGetRoleService? _getRoleService;
    private IGetUserWithRolesService? _getUserWithRolesService; 
    #endregion
    
    #region Properties
    public IGetUsersService GetUsersService => _getUsersService ??= new GetUsersService(Context);

    public IGetRemovedUsersService GetRemovedUsersService =>
        _getRemovedUsersService ??= new GetRemovedUsersService(Context);
    public IGetRolesService GetRolesService => _getRolesService ??= new GetRolesService(Context);

    public IGetRoleService GetRoleService => _getRoleService ??= new GetRoleService(Context);
    public IGetUserWithRolesService GetUserWithRolesService => _getUserWithRolesService ??= new GetUserWithRolesService(Context);

    #endregion /Properties
}