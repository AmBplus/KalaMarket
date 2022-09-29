namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductDetailForSite;

public class ProductDetailForSiteDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Brand { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> Images { get; set; }
    public List<ProductDetailForSiteFeaturesDto> Features { get; set; }
}