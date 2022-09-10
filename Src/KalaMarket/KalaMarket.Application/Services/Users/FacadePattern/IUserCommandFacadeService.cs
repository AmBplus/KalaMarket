using KalaMarket.Application.Services.Users.Commands.ChangeActivationUser;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;
using KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;
using KalaMarket.Application.Services.Users.Commands.EditUser;
using KalaMarket.Application.Services.Users.Commands.RegisterUser.Interfaces;
using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Application.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Application.Services.Users.FacadePattern
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
