using KalaMarket.Application.Identity.Services.Users.Queries.Dto;
using KalaMarket.Application.Identity.Services.Users.Queries.GetRoles.Interface;
using KalaMarket.Application.Interfaces.Context;
using Mapster;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetRoles.Implement;

public class GetRemovedRoleService : IGetRolesService
{
    #region Ctor

    public GetRemovedRoleService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion Ctor

    #region Property_Field

    private IKalaMarketContext Context { get; }

    #endregion Property_Field

    #region Method

    public ResultGetRolesDto Execute()
    {
        var roles = Context.Roles.Where(x => x.IsRemoved).ProjectToType<GetRoleDto>().ToList();
        return new ResultGetRolesDto
        {
            Roles = roles
        };
    }

    #endregion Method
}