using KalaMarket.Application.Identity.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Identity.Services.Users.Commands.EditUser;
using KalaMarket.Application.Identity.Services.Users.Commands.RegisterUser.Interfaces;

namespace KalaMarket.Application.Identity.Services.Users.FacadePattern;

public interface IUserCommandFacadeService
{
    IRegisterUserService RegisterUserService { get; }
    IChangeActivationUserService ChangeActivationUserService { get; }
    IChangeRemoveRoleService ChangeRemoveRoleService { get; }
    IChangeRemoveUserService ChangeRemoveUserService { get; }
    IEditUserService EditUserService { get; }
}