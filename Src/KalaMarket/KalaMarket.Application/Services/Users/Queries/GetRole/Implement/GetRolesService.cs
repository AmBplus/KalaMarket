using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Queries.GetRole.Dto;
using KalaMarket.Application.Services.Users.Queries.GetRole.Interface;
using KalaMarket.Application.Services.Users.Queries.GetUsers;
using Mapster;

namespace KalaMarket.Application.Services.Users.Queries.GetRole.Implement;

public class GetRolesService : IGetRolesService
{
    #region Property_Field
    private IKalaMarketContext Context { get; set; }
    #endregion Property_Field

    #region Ctor
    public GetRolesService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion Ctor

    #region Method
    public ResultGetRolesDto Execute()
    {
        var roles = Context.Roles.ProjectToType<GetRoleDto>().ToList();
        return new ResultGetRolesDto()
        {
            Roles = roles,
        };
    }
    #endregion Method
}