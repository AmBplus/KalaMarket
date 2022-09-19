namespace KalaMarket.Application.User.Services.Users.Queries.GetUsers.Dto;

public class GetUserWithRoleDto
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public IEnumerable<string> Role { get; set; }
}