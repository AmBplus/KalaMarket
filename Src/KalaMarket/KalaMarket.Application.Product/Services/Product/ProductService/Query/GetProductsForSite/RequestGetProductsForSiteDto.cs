using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForSite;

public class RequestGetProductsForSiteDto
{
    public int Page { get; set; } = 1;
    public long? CategoryId { get; set; }
    public string? SearchKey { get; set; }
    public byte PageSize { get; set; } = KalaMarketConstants.Page.PageSizeInWeb;
    public OrderingProduct Order { get; set; } = OrderingProduct.NotOrder;
}