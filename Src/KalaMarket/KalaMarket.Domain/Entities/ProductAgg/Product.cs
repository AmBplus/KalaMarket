using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Entities.ProductAgg;

public class Product : BaseEntity<long>
{
    #region Constructors

    protected Product()
    {

    }
    public Product(string name, string description,
        long categoryId , int inventory = 0 ,
        bool displayed = true, decimal price = 0,
        ushort? brandId = null,
        ICollection<ProductFeatures>? features = null,
        ICollection<ProductImages>? images = null)
    {
        Name = name;
        Description = description;
        Inventory = inventory;
        Displayed = displayed;
        Price = price;
        BrandId = brandId;
        CategoryId = categoryId;
        Features = features ?? new List<ProductFeatures>();
        Images = images ?? new List<ProductImages>();
    }

    #endregion /Constructors

    #region Methods

    public bool Edit(string name, string description,
        long categoryId, ushort? brandId)
    {
        Name = name;
        Description = description;
        BrandId = brandId;
        CategoryId = categoryId;
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


    public string Name { get; set; }
    public string Description { get; set; }
    public int Inventory { get; set; }
    public bool Displayed { get; set; }
    public Brand Brand { get; set; }
    public decimal Price { get; set; }
    public ushort? BrandId { get; set; }
    public virtual Category Category { get; private set; }
    public long CategoryId { get; set; }
    public virtual ICollection<ProductFeatures> Features { get; private set; }
    public virtual ICollection<ProductImages> Images { get; private set; }

    #endregion
}