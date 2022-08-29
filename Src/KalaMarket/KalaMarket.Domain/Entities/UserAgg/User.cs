using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Entities.UserAgg;

public class User : BaseEntity<long> , IIsActive
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<UserInRole> UserInRoles{ get; set; }
    public bool IsActive { get; set; }
}