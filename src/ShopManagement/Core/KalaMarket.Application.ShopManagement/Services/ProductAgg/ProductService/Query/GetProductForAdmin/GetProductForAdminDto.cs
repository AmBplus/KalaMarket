namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductForAdmin;

public class GetProductForAdminDto
{
    public long Id { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public bool Displayed { get; set; }
    public int Inventory { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}