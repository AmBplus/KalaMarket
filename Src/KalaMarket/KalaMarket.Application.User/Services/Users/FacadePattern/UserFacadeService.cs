using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.User.Services.Users.FacadePattern;

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