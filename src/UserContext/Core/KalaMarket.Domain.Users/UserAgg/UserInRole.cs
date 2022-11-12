using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Users.UserAgg;

public class UserInRole : BaseEntity<long>
{
    public long UserId { get; set; }
    public virtual User User { get; set; }
    public long RoleId { get; set; }
    public virtual Role Role { get; set; }
}