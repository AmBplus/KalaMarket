using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveUser;

public interface IChangeRemoveUserService
{
    ResultDto Execute(long id);
}