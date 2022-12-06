using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.ShopManagement.ProductAgg;

public class CartItem : BaseEntity<long>
{
    #region Ctor

    private CartItem()
    {
    }

    public CartItem(long productId, decimal price, int count, long cartId)
    {
        ProductId = productId;
        Price = price;
        Count = count;
        CartId = cartId;
    }

    #endregion /Ctor

    #region Properties

    public virtual Product Product { get; set; }

    public long ProductId { get; }
    public decimal Price { get; }
    public int Count { get; private set; }
    public long CartId { get; }
    public virtual Cart Cart { get; set; }

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