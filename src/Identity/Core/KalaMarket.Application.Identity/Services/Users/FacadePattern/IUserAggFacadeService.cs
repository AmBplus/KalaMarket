namespace KalaMarket.Application.Identity.Services.Users.FacadePattern;

public interface IUserAggFacadeService
{
    IUserQueryFacadeService UserQuery { get; }
    IUserCommandFacadeService UserCommand { get; }
}