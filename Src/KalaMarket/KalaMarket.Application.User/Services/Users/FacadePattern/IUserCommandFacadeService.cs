using KalaMarket.Application.User.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.User.Services.Users.Commands.EditUser;
using KalaMarket.Application.User.Services.Users.Commands.RegisterUser.Interfaces;

namespace KalaMarket.Application.User.Services.Users.FacadePattern
{
    public interface IUserCommandFacadeService
    {
        IRegisterUserService RegisterUserService { get; }
        IChangeActivationUserService ChangeActivationUserService { get; }
        IChangeRemoveRoleService ChangeRemoveRoleService { get; }
        IChangeRemoveUserService ChangeRemoveUserService { get; }
        IEditUserService EditUserService { get; }
    }
}
