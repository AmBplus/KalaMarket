using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Application.Identity.Services.Users.Queries.GetUsers.Dto;

public class GetUserDto : IIsActive
{
    public long Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}