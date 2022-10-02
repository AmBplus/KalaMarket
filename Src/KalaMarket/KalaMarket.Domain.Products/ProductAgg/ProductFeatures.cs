using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Products.ProductAgg;

public class ProductFeatures : BaseEntity<long>
{
    #region Constructors

    protected ProductFeatures()
    {

    }
    public ProductFeatures(long productId, string keyName, string keyValue)
    {
        ProductId = productId;
        KeyName = keyName;
        KeyValue = keyValue;
    }

    #endregion /Constructors

    #region Method

    public bool Edit(long productId, string keyName, string keyValue)
    {
        ProductId = productId;
        KeyName = keyName;
        KeyValue = keyValue;
        return true;
    }

    #endregion /Method

    #region Properties
    public virtual Product Product { get; private set; }
    public long ProductId { get; private set; }
    public string KeyName { get; private set; }
    public string KeyValue { get; private set; }
    #endregion /Properties
}