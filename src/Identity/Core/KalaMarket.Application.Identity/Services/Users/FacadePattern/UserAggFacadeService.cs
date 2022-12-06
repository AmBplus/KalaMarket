using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.Identity.Services.Users.FacadePattern;

public class UserAggFacadeService : IUserAggFacadeService
{
    #region Constructor

    public UserAggFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion

    #region Fields

    private readonly IKalaMarketContext? Context;
    private IUserQueryFacadeService? _userQuery;
    private IUserCommandFacadeService? _userCommand;
    private ILoggerManger Logger { get; }

    #endregion

    #region Properties

    public IUserQueryFacadeService UserQuery => _userQuery ??= new UserQueryFacadeService(Context, Logger);
    public IUserCommandFacadeService UserCommand => _userCommand ??= new UserCommandFacadeService(Context, Logger);

    #endregion
}