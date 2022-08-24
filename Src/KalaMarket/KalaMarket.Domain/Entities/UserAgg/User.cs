namespace KalaMarket.Domain.Entities.UserAgg;

public class User : BaseEntity<long>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<UserInRole> UserInRoles{ get; set; }
}