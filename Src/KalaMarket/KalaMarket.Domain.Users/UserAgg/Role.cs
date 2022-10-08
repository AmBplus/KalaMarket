using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Users.UserAgg;

public class Role : BaseEntity<long>
{
    public string Name { get; set; }
    public virtual ICollection<UserInRole> UserInRoles { get; set; }
}