using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Entities.ProductAgg.BrandAgg;

public class Brand : BaseEntity<ushort>
{
    public string Name { get; private set; }

}