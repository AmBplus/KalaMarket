using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.User.Services.Users.Commands.ChangeActivationUser;

public interface IChangeActivationUserService
{
    ResultDto Execute(long id);
}