using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Entities.ProductAgg;

public class Brand : BaseEntity<ushort>
{
    #region Constructors
    protected Brand() { }
    public Brand(string name)
    {
        Name = name;
        Products = new List<Product>();
    }
    #endregion /Constructors

    #region Properties
    public string Name { get; private set; }
    public ICollection<Product> Products { get;private set; }
    #endregion /Properties

    #region Method

    public bool Edit(string name)
    {
        Name = name;
        return true;
    }

    #endregion
}