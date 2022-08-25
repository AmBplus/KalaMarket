namespace KalaMarket.Application.Services.Users.Commands.RegisterUser;

public class RequestRegisterUserService
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public List<RolesInRegisterUserDto> Roles { get; set; }
}