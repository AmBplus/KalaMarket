using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.User.Services.Users.Commands.ChangeRemoveRole;

public interface IChangeRemoveRoleService
{
    ResultDto Execute(long id);
}