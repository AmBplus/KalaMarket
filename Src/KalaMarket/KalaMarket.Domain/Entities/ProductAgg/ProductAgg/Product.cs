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
    public ushort BrandId { get; set; }
    public virtual Category Category { get;private set; }
    public long CategoryId { get; set; }
    public virtual ICollection<ProductFeatures> Features { get;private set; }
    public virtual ICollection<ProductImages> Images { get;private set; }

    public Product()
    {
        Features = new List<ProductFeatures>();
        Images = new List<ProductImages>();
    }

    
}