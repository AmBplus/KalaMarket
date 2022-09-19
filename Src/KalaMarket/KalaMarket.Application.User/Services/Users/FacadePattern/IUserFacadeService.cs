namespace KalaMarket.Application.User.Services.Users.FacadePattern;

public interface IUserFacadeService 
{ 
    IUserQueryFacadeService UserQuery { get; }
    IUserCommandFacadeService UserCommand { get; }
}