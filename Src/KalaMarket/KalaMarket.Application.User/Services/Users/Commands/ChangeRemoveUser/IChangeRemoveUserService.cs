using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveUser;

public interface IChangeRemoveUserService
{
    ResultDto Execute(long id);
}