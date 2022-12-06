namespace KalaMarket.Application.Identity.Services.Users.Queries.GetRole;

public interface IGetRoleService
{
    long? Execute(string role);
}