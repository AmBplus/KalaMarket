namespace KalaMarket.Application.Product.Services.ProductAgg.Carts;

public class CartDto
{
    public IEnumerable<CartItemDto> CartItemDtos { get; set; }
    public decimal TotalPrice { get; set; }
    public int Count { get; set; }
}