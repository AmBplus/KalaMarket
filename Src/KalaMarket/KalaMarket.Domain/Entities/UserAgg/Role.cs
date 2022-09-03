using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Entities.UserAgg;

public class Role : BaseEntity<long>
{
    public string Name { get; set; }
    public ICollection<UserInRole> UserInRoles { get; set; }
}