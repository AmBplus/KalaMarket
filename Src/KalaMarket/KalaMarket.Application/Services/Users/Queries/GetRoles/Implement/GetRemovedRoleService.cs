using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Users.Queries.GetRole.Dto;
using KalaMarket.Application.Services.Users.Queries.GetRole.Interface;
using Mapster;

namespace KalaMarket.Application.Services.Users.Queries.GetRole.Implement;

public class GetRemovedRoleService : IGetRolesService
{
    #region Property_Field
    private IKalaMarketContext Context { get; set; }
    #endregion Property_Field

    #region Ctor
    public GetRemovedRoleService(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion Ctor

    #region Method
    public ResultGetRolesDto Execute()
    {
        var roles = Context.Roles.Where(x=>x.IsRemoved).ProjectToType<GetRoleDto>().ToList();
        return new ResultGetRolesDto()
        {
            Roles = roles,
        };
    }
    #endregion Method
}