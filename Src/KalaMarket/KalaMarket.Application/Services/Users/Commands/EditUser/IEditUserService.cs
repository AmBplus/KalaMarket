using KalaMarket.Application.Services.Users.Commands.EditUser.Dto;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.EditUser;

public interface IEditUserService
{
    ResultDto Execute(EditUserDto editUser);
}