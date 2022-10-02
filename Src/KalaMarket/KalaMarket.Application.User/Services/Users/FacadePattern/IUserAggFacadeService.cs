namespace KalaMarket.Application.User.Services.Users.FacadePattern;

public interface IUserAggFacadeService
{
    IUserQueryFacadeService UserQuery { get; }
    IUserCommandFacadeService UserCommand { get; }
}