using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Domain.Entities.ProductAgg.ProductAgg;

namespace KalaMarket.Domain.Entities.ProductAgg;

public class ProductFeatures : BaseEntity<long>
{
    public virtual Product Product { get; set; }
    public long ProductId { get; set; }
    public string KeyName { get; set; }
    public string Value { get; set; }
}