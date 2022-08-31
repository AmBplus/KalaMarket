namespace KalaMarket.Application.Services.Users.Queries.GetRole;

public interface IGetRoleService
{
    long? Execute(string role);
}