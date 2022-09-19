namespace KalaMarket.Application.User.Services.Users.Queries.GetUsers.Dto;

public class ResultGetUserDto
{
    public List<GetUserDto> Users { get; set; }
    public int Rows { get; set; }
}