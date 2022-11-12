using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Products.ProductAgg;

public class Cart : BaseEntity<long>
{
    #region Ctor
    private Cart(){}
    public Cart(Guid deviceId, long? userId = null)
    {
        UserId = userId;
        DeviceId = deviceId;
        Finished = false;
        TotalPrice = 0;
        CartItems = new List<CartItem>();
    }

    #endregion /Ctor

    #region Properties

    public long? UserId { get; private set; }
    public decimal TotalPrice { get; private set; }
    public virtual ICollection<CartItem> CartItems { get; }
    public Guid DeviceId { get; set; }

    #endregion /Properties

    #region Methods

    public bool SetUserId(long id)
    {
        UserId = id;
        return true;
    }

    public bool Finished { get; private set; }

    public bool IncreaseTotalPrice(decimal price)
    {
        TotalPrice += price;
        return true;
    }

    public bool DecreaseTotalPrice(decimal price)
    {
        if (TotalPrice - price >= 0)
        {
            TotalPrice -= price;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Finish Cart Payment
    /// </summary>
    /// <returns></returns>
    public bool Finish()
    {
        Finished = true;
        return true;
    }

    #endregion /Methods
}