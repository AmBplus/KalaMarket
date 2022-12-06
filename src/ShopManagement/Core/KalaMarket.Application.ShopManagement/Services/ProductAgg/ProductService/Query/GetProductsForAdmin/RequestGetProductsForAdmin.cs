using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductsForAdmin;

public class RequestGetProductsForAdmin
{
    public byte PageSize { get; set; } = KalaMarketConstants.Page.PageSize;
    public int Page { get; set; } = 1;
    public bool GetIsRemoved { get; set; } = false;
}