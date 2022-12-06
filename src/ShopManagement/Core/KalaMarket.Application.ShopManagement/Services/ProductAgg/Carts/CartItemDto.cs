namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Carts;

public class CartItemDto
{
    public long Id { get; set; }
    public string ProductImage { get; set; }
    public string ProductName { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}