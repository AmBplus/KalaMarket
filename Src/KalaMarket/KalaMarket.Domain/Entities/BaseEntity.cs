namespace KalaMarket.Domain.Entities;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; }
    public DateTime InserTime { get; set; }
    public DateTime? UpdateTime { get; set; }
    public bool IsRemoved { get; set; } = false;
    public DateTime? RemoveTime { get; set; }
     

}