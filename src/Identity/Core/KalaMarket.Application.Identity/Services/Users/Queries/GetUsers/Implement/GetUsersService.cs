using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;
using KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Interfaces;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;
using Mapster;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Implement;

public class GetUsersService : IGetUsersService
{
    #region Ctor

    public GetUsersService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion Ctor

    /// <summary>
    ///     Get Users Information
    /// </summary>
    /// <param name="requestGetUser"></param>
    /// <returns></returns>

    #region Method

    public ResultGetUserDto Execute(RequestGetUserDto requestGetUser)
    {
        var users = Context.Users.AsQueryable();
        users = users.QuerySearchGenerator(requestGetUser.SearchKey,
            p => p.FullName.ToLower().Contains(requestGetUser.SearchKey.ToLower()) ||
                 p.Email.ToLower().Contains(requestGetUser.SearchKey.ToLower()));
        // filter by IsRemoved 
        users = users.Where(x => !x.IsRemoved);
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

    private readonly IKalaMarketContext Context;
    private int rowCount;

    #endregion Property_Field
}