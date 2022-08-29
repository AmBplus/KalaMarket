namespace KalaMarket.Application.Services.Users.Commands.RegisterUser.Dto;

public class RequestRegisterUserDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public List<RolesInRegisterUserDto> Roles { get; set; }
}