using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Products.ProductAgg;

public class CartItem : BaseEntity<long>
{
    #region Ctor
    public CartItem(long productId, decimal price, int count, long cartId)
    {
        ProductId = productId;
        Price = price;
        Count = count;
        CartId = cartId;
    }

    #endregion /Ctor

    #region Properties
    public virtual Product Product { get; private set; }
    public long ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Count { get; private set; }
    public long CartId { get; private set; }
    public virtual Cart Cart { get; private set; }
    #endregion /Properties
    
    #region Methods
    public bool IncreaseCount()
    {
        Count++;
        return true;
    }
    public bool DecreaseCount()
    {
        if (Count - 1 >= 0)
        {
            Count--;
            return true;
        }
        return false;
    }
    #endregion /Methods
}