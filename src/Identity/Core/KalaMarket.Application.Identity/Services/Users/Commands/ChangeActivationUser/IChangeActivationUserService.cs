using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Commands.ChangeActivationUser;

public interface IChangeActivationUserService
{
    ResultDto Execute(long id);
}