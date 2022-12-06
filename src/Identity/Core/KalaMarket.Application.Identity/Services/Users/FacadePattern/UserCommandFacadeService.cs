using KalaMarket.Application.Identity.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Identity.Services.Users.Commands.EditUser;
using KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Implement;
using KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;

namespace KalaMarket.Application.Identity.Services.Users.FacadePattern;

public class UserCommandFacadeService : IUserCommandFacadeService
{
    #region Constructor

    public UserCommandFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Fields

    private readonly IKalaMarketContext Context;
    private readonly ILoggerManger Logger;
    private IRegisterUserService? _registerUserService;
    private IChangeActivationUserService? _changeActivationUserService;
    private IChangeRemoveRoleService? _changeRemoveRoleService;
    private IChangeRemoveUserService? _changeRemoveUserService;
    private IEditUserService? _editUserService;

    #endregion /Fields

    #region Properties

    public IChangeActivationUserService ChangeActivationUserService =>
        _changeActivationUserService ??= new ChangeActivationUserService(Context, Logger);

    public IChangeRemoveRoleService ChangeRemoveRoleService =>
        _changeRemoveRoleService ??= new ChangeRemoveRoleService(Context, Logger);

    public IChangeRemoveUserService ChangeRemoveUserService =>
        _changeRemoveUserService ??= new ChangeRemoveUserService(Context, Logger);

    public IEditUserService EditUserService => _editUserService ??= new EditUserService(Context, Logger);

    public IRegisterUserService RegisterUserService =>
        _registerUserService ??= new RegisterUserService(Context, Logger);

    #endregion /Properties
}