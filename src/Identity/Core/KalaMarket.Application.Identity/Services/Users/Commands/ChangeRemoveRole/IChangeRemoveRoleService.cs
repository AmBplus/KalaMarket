using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Commands.ChangeRemoveRole;

public interface IChangeRemoveRoleService
{
    ResultDto Execute(long id);
}