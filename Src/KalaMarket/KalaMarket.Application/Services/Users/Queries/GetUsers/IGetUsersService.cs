namespace KalaMarket.Application.Services.Users.Queries.GetUsers;

public interface IGetUsersService
{
    ResultGetUserDto Execute(RequestGetUserDto requestGetUser);
}