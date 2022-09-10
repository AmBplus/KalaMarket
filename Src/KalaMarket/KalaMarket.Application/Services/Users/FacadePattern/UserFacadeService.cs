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
using KalaMarket.Shared;

namespace KalaMarket.Application.Services.Users.FacadePattern;

public class UserFacadeService : IUserFacadeService
{
    #region Constructor
    public UserFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    } 
    #endregion
   
    #region Fields
    private IKalaMarketContext? Context;
    private IUserQueryFacadeService? _userQuery;
    private IUserCommandFacadeService? _userCommand;
    private ILoggerManger Logger { get; }
    #endregion
   
    #region Properties
    public IUserQueryFacadeService UserQuery => _userQuery ?? new UserQueryFacadeService(Context, Logger);
    public IUserCommandFacadeService UserCommand => _userCommand ?? new UserCommandFacadeService(Context, Logger); 
    #endregion
}