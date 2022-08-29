using KalaMarket.Shared;

namespace KalaMarket.Domain.Entities;

public class BaseEntityWithoutId
{
    public BaseEntityWithoutId()
    {
       UpdateTime =  InserTime = Utility.Now;
    }
    public DateTime InserTime { get; }
    public DateTime? UpdateTime { get; set; }
    public bool IsRemoved { get; set; } = false;
    public DateTime? RemoveTime { get; set; }

}