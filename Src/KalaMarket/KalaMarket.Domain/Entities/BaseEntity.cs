namespace KalaMarket.Domain.Entities;

public abstract class BaseEntity<TKey> : BaseEntityWithoutId
{
    public TKey Id { get; set; }
}