namespace KalaMarket.Application.Services.Users.Queries.GetUsers;

public class RequestGetUserDto
{
   public string? SearchKey { get; set; }
   public int Page { get; set; } = 1;
}