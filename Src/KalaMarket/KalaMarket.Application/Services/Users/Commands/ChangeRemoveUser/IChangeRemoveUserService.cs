using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.ChangeRemoveUser;

public interface IChangeRemoveUserService
{
    ResultDto Execute(long id);
}