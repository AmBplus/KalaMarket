using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Domain.Entities.ProductAgg.ProductAgg;

namespace KalaMarket.Domain.Entities.ProductAgg;

public class Brand : BaseEntity<ushort>
{
    public string Name { get; private set; }
    public ICollection<Product> Products { get; set; }
}