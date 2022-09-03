using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.Services.Users.Queries.GetRole;

public class GetRoleService : IGetRoleService
{
    public GetRoleService(IKalaMarketContext context)
    {
        Context = context;
    }

    IKalaMarketContext Context { get;  }
    public long? Execute(string role)
    {
        var result = Context.Roles.FirstOrDefault(x => x.Name == role);
        return result?.Id;

    }
}