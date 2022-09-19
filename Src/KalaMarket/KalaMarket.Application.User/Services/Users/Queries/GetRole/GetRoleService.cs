
using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.User.Services.Users.Queries.GetRole;

public class GetRoleService : IGetRoleService
{
    public GetRoleService(IKalaMarketContext context)
    {
        Context = context;
    }

    IKalaMarketContext Context { get;  }
    /// <summary>
    ///  Get Role Id
    /// </summary>
    /// <param name="role"></param>
    /// <returns>Null Or Role Id</returns>
    public long? Execute(string role)
    {
        var result = Context.Roles.FirstOrDefault(x => x.Name == role);
        return result?.Id;

    }
}