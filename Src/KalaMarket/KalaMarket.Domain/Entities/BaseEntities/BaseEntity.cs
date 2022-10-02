namespace KalaMarket.Domain.Entities.BaseEntities;

public abstract class BaseEntity<TKey> : BaseEntityWithoutId
{
    public BaseEntity() : base()
    {

    }
    public TKey Id { get; set; }
}