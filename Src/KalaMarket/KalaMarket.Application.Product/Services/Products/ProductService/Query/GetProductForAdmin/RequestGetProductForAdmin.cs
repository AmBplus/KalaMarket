namespace KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductForAdmin;

public class RequestGetProductForAdmin
{
    public long Id { get; set; }
    public bool GetIsRemoved { get; set; } = false;
}
