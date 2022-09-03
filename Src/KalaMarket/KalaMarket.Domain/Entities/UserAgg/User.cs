using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Shared;
using KalaMarket.Shared.Security;

namespace KalaMarket.Domain.Entities.UserAgg;

public class User : BaseEntity<long> , IIsActive
{
    protected User()
    {
        
    }

    public User(string fullName, string email, string password)
    {
        this.FullName = fullName;
        this.Email = email;
        this.Password = password.GetSha256();
        IsActive = true;
        UserInRoles = new List<UserInRole>();
    }
    public bool Update(string fullName)
    {
        FullName = fullName;
        base.UpdateTimes();
        return true;
    }
    public bool ChangeActivation()
    {
        IsActive = !IsActive;
        return true;
    }
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public virtual ICollection<UserInRole> UserInRoles { get; private set; }
    public bool IsActive { get;private set; }

    bool IIsActive.IsActive
    {
        get => this.IsActive;
        set => this.IsActive = value;
    }
}