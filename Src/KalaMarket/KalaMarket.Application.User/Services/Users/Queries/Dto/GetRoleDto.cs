using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Application.User.Services.Users.Queries.Dto;

public class GetRoleDto : BaseEntity<long>
{
    public string Name { get; set; }
}