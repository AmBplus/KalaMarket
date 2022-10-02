namespace KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductsForSite;

public class ResultGetProductsForSiteDto
{

    public List<GetProductForSiteDto> Products { get; set; }
    public int TotalRow { get; set; }
}