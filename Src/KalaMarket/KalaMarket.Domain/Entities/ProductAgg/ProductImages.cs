using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Domain.Entities.ProductAgg.ProductAgg;

namespace KalaMarket.Domain.Entities.ProductAgg;

public class ProductImages : BaseEntity<long>
{
    public virtual Product Product { get; set; }
    public long ProductId { get; set; }
    public string Src { get; set; }
}