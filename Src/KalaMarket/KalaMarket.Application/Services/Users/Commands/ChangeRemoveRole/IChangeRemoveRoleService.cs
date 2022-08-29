using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Users.Commands.ChangeRemoveRole;

public interface IChangeRemoveRoleService
{
    ResultDto Execute(long id);
}