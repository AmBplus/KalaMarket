using KalaMarket.Application.Identity.Services.Users.Queries.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetRoles.Interface;

public interface IGetRemovedRole
{
    ResultGetRolesDto Execute();
}