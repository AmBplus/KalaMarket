namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductForAdmin;

public class RequestGetProductForAdmin
{
    public long Id { get; set; }
    public bool GetIsRemoved { get; set; } = false;
}
