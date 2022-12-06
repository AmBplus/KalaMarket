using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;

public interface IGetUserWithRolesService
{
    ResultDto<GetUserWithRoleDto> Execute(RequestGetUserWithRolesDto request);
}