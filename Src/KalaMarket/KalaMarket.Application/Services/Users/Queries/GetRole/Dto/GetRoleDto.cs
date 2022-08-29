using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Application.Services.Users.Queries.GetRole.Dto;

public class GetRoleDto : BaseEntity<long>
{
    public string Name { get; set; }
}