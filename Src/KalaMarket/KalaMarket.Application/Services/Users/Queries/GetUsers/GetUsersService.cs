using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;
using Mapster;

namespace KalaMarket.Application.Services.Users.Queries.GetUsers;

public class GetUsersService : IGetUsersService
{
    private readonly IKalaMarketContext Context;
    private readonly int pageSize = 8;
    public GetUsersService(IKalaMarketContext context)
    {
        Context = context;
    }

    public ResultGetUserDto Execute(RequestGetUserDto requestGetUser)
    {
        var users = Context.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(requestGetUser.SearchKey))
        {
            users = users.Where(p => p.FullName.Contains(requestGetUser.SearchKey) && p.Email.Contains(requestGetUser.SearchKey));
        }

        int  rowCount = 0 ;
        var getUsers = users.ProjectToType<GetUserDto>().ToPaged(requestGetUser.Page, pageSize, out rowCount).ToList();
        return new ResultGetUserDto()
        {
            Users = getUsers,
            Rows = rowCount
        };
    }

}