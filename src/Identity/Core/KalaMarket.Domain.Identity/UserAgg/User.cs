using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Shared.Security;

namespace KalaMarket.Domain.Identity.UserAgg;

public class User : BaseEntityWithActive<long>
{
    protected User()
    {
    }

    public User(string fullName, string email, string password)
    {
        FullName = fullName;
        Email = email;
        Password = password.GetSha256();
        UserInRoles = new List<UserInRole>();
    }

    public string FullName { get; private set; }
    public string Email { get; }
    public string Password { get; }
    public virtual ICollection<UserInRole> UserInRoles { get; }

    public bool Update(string fullName)
    {
        FullName = fullName;
        UpdateTimes();
        return true;
    }
}