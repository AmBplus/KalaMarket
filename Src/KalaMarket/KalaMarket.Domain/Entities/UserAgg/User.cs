using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Shared;
using KalaMarket.Shared.Security;

namespace KalaMarket.Domain.Entities.UserAgg;

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
    public bool Update(string fullName)
    {
        FullName = fullName;
        base.UpdateTimes();
        return true;
    }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public virtual ICollection<UserInRole> UserInRoles { get; private set; }
    
  
}