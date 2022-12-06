using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;
using Mapster;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Implement;

public class GetRemovedUsersService : IGetRemovedUsersService
{
    #region Ctor

    public GetRemovedUsersService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Ctor

    #region Method

    public ResultGetUserDto Execute(RequestGetUserDto requestGetUser)
    {
        var users = Context.Users.AsQueryable();
        // Implement SearchKey If Exists 
        users = users.QuerySearchGenerator(requestGetUser.SearchKey,
            p => p.FullName.Contains(requestGetUser.SearchKey) && p.Email.Contains(requestGetUser.SearchKey));
        // filter by IsRemoved True 
        users = users.Where(x => x.IsRemoved);
        // Pagination 
        var getUsers = users.ProjectToType<GetUserDto>()
            .ToPaged(requestGetUser.Page, KalaMarketConstants.Page.PageSize, out rowCount).ToList();
        // Set GetUser And Count Of All User
        return new ResultGetUserDto
        {
            Users = getUsers,
            Rows = rowCount
        };
    }

    #endregion

    #region Property_Field

    private IKalaMarketContext Context { get; }
    private int rowCount;

    #endregion /Property_Field
}