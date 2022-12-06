using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;

public interface IGetRemovedUsersService
{
    ResultGetUserDto Execute(RequestGetUserDto requestGetUser);
}