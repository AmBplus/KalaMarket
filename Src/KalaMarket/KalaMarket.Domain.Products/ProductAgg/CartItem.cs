using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Products.ProductAgg;

public class CartItem : BaseEntity<long>
{
    public CartItem(long productId, decimal price, int count, long cartId)
    {
        ProductId = productId;
        Price = price;
        Count = count;
        CartId = cartId;
    }

    public Product Product { get; private set; } 
    public long ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Count { get; private set; }
    public long CartId { get; private set; }
    public Cart Cart { get;private set; }
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
}