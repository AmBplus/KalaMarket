namespace KalaMarket.Domain.Entities.BaseEntities;

public class BaseEntityWithActive<T> :BaseEntity<T>
{
    public BaseEntityWithActive():base()
    {
        IsActive = true;
    }
    public bool IsActive { get;private set; }

    public bool ChangeActivation()
    {
        IsActive = !IsActive;
        return true;
    }
}