using KalaMarket.Application.User.Services.Users.Queries.GetUsers.Dto;

namespace KalaMarket.Application.User.Services.Users.Queries.GetUsers.Interfaces;

public interface IGetRemovedUsersService
{
    ResultGetUserDto Execute(RequestGetUserDto requestGetUser);
}