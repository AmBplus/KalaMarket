using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Products.ProductAgg;

public class Brand : BaseEntityWithActive<ushort>
{
    #region Method

    public bool Edit(string name)
    {
        Name = name;
        return true;
    }

    #endregion

    #region Constructors

    protected Brand()
    {
    }

    public Brand(string name)
    {
        Name = name;
        Products = new List<Product>();
    }

    #endregion /Constructors

    #region Properties

    public string Name { get; private set; }
    public virtual ICollection<Product> Products { get; }

    #endregion /Properties
}