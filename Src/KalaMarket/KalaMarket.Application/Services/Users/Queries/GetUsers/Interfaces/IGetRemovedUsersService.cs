using KalaMarket.Application.Services.Users.Queries.GetRole;
using KalaMarket.Application.Services.Users.Queries.GetUsers.Dto;

namespace KalaMarket.Application.Services.Users.Queries.GetUsers.Interfaces;

public interface IGetRemovedUsersService
{
    ResultGetUserDto Execute(RequestGetUserDto requestGetUser);
}