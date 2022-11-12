namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductsForSite;

public class ResultGetProductsForSiteDto
{
    public List<GetProductForSiteDto> Products { get; set; }
    public int TotalRow { get; set; }
}