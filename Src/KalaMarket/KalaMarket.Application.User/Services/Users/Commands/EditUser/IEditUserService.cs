using KalaMarket.Application.User.Services.Users.Commands.EditUser.Dto;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.User.Services.Users.Commands.EditUser;

public interface IEditUserService
{
    ResultDto Execute(EditUserDto editUser);
}