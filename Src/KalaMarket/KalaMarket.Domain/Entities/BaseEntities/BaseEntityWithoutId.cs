using KalaMarket.Shared;

namespace KalaMarket.Domain.Entities.BaseEntities;

public class BaseEntityWithoutId
{
    public BaseEntityWithoutId()
    {
        UpdateTime = Utility.Now;
        InsertTime = Utility.Now;
    }
    public DateTime InsertTime { get; private set; }
    public DateTime? UpdateTime { get;private set; }
    public bool IsRemoved { get;private set; } = false;
    public DateTime? RemoveTime { get;private set; }

    public bool UpdateTimes()
    {
        UpdateTime = Utility.Now;
        return true;
    }

    public bool ChangeRemoveStatus()
    {
        IsRemoved = !IsRemoved;
        RemoveTime = Utility.Now;
        return true;
    }
}