using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Domain.Entities.ProductAgg.CategoryAgg;

namespace KalaMarket.Domain.Entities.ProductAgg.ProductAgg;

public class Product : BaseEntity<long>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Inventory { get; set; }
    public bool Displayed { get; set; }
    public Brand Brand { get; set; }
    public long BrandId { get; set; }
    public virtual Category Category { get; set; }
    public long CategoryId { get; set; }
    public virtual ICollection<ProductFeatures> Features { get; set; }
    public virtual ICollection<ProductImages> Images { get; set; }
}