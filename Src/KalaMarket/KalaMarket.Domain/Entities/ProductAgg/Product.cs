using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Entities.ProductAgg;

public class Product : BaseEntity<long>
{
    #region Constructors

    protected Product()
    {

    }
    public Product(string name, string description, string slug,
        long categoryId , int inventory = 0 ,
        bool displayed = true, decimal price = 0,
        ushort? brandId = null)
    {
        Name = name;
        Description = description;
        Inventory = inventory;
        Displayed = displayed;
        Price = price;
        BrandId = brandId;
        CategoryId = categoryId;
        Slug = slug;
        Features = new List<ProductFeatures>();
        Images =  new List<ProductImages>();
    }

    #endregion /Constructors

    #region Methods

    public bool Edit(string name, string description,
        long categoryId, ushort? brandId,string slug)
    {
        Name = name;
        Description = description;
        BrandId = brandId;
        CategoryId = categoryId;
        Slug = slug;
        return true;
    }

    #region Inventory Methods

    public bool IncreaseInventoryBy(int number)
    {
        Inventory += number;
        return true;
    }
    public bool DecreaseInventoryBy(int number)
    {
        if (Inventory - number < 0)
        {
            return false;
        }
        Inventory -= number;
        return true;
    }
    public bool SetInventory(int number)
    {
        Inventory = number;
        return true;
    }

    public bool SetFeature(ICollection<ProductFeatures> productFeatures)
    {
        Features = productFeatures;
        return true;
    }
    public bool SetImages(ICollection<ProductImages> productImages)
    {
        Images = productImages;
        return true;
    }
    #endregion /Inventory Methods

    #region Price Methods

    public bool IncreasePriceyBy(int price)
    {
        Price += price;
        return true;
    }
    public bool DecreasePriceBy(int price)
    {
        if (Price - price < 0)
        {
            return false;
        }
        Price -= price;
        return true;
    }
    public bool SetPrice(int price)
    {
        Price = price;
        return true;
    }

    #endregion /Price Methods
    /// <summary>
    /// Display Or UnDisplay Product 
    /// </summary>
    /// <returns></returns>
    public bool ShowProduct()
    {
        Displayed = !Displayed;
        return true;
    }
    #endregion /Methods

    #region Properties


    public string Name { get;private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
    public int Inventory { get; private set; }
    public bool Displayed { get; private set; }
    public Brand Brand { get; set; }
    public decimal Price { get; private set; }
    public ushort? BrandId { get; private set; }
    public virtual Category Category { get;  set; }
    public long CategoryId { get;private set; }
    public virtual ICollection<ProductFeatures> Features { get; private set; }
    public virtual ICollection<ProductImages> Images { get; private set; }

    #endregion
}