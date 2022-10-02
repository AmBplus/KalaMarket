using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Products.ProductAgg;

public class ProductImages : BaseEntity<long>
{
    #region Constructor

    public ProductImages(long productId, string productName, string src)
    {
        ProductId = productId;
        ProductName = productName;
        Src = src;
    }
    protected ProductImages()
    {

    }

    #endregion

    #region Properties

    public virtual Product Product { get; private set; }
    public long ProductId { get; private set; }
    public string ProductName { get; private set; }
    public string Src { get; private set; }

    #endregion /Properties

    #region Methods
    public bool Edit(long productId, string productName, string src)
    {
        ProductId = productId;
        ProductName = productName;
        Src = src;
        return true;
    }
    public bool Edit(long productId, string productName)
    {
        ProductId = productId;
        ProductName = productName;
        return true;
    }
    #endregion Methods
}