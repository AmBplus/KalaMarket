namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetDetailProductForAdmin;

public class ProductDetailForAdmindto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public bool Displayed { get; set; }
    public List<ProductDetailFeatureDto> Features { get; set; }
    public List<ProductDetailImagesDto> Images { get; set; }
}