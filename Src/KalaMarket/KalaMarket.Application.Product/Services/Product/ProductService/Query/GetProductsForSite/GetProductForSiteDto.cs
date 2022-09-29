namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForSite;

public class GetProductForSiteDto
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string ImageSrc { get; set; }
    public int Star { get; set; }
    public decimal Price { get; set; }
    public string Slug { get; set; }
}