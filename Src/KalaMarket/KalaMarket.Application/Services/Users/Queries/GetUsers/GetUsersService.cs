using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;
using Mapster;

namespace KalaMarket.Application.Services.Users.Queries.GetUsers;

public class GetUsersService : IGetUsersService
{
    #region Property_Field

    private readonly IKalaMarketContext Context;
    private readonly int pageSize = 8;

    #endregion Property_Field

    #region Ctor

    public GetUsersService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion Ctor
   
    /// <summary>
    /// Get Users Information
    /// </summary>
    /// <param name="requestGetUser"></param>
    /// <returns></returns>

    #region Method

    public ResultGetUserDto Execute(RequestGetUserDto requestGetUser)
    {
        var users = Context.Users.AsQueryable();
        // Implement SearchKey If Exists 
        if (!string.IsNullOrWhiteSpace(requestGetUser.SearchKey))
        {
            users = users.Where(p => p.FullName.Contains(requestGetUser.SearchKey) && p.Email.Contains(requestGetUser.SearchKey));
        }
        int  rowCount = 0 ;
        // Pagination 
        var getUsers = users.ProjectToType<GetUserDto>().ToPaged(requestGetUser.Page, pageSize, out rowCount).ToList();
        // Set GetUser And Count Of All User
        return new ResultGetUserDto()
        {
            Users = getUsers,
            Rows = rowCount
        };
    }

    #endregion

}