using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.ChangeActivationUser;

public interface IChangeActivationUserService
{
    ResultDto Execute(long id);
}