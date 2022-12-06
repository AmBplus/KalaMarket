using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;

public interface IGetUsersService
{
    ResultGetUserDto Execute(RequestGetUserDto requestGetUser);
}