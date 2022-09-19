namespace KalaMarket.Application.Product.Services.Product.ProductService.Commands.AddProduct;

public class RequestAddProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public long CategoryId { get; set; }
    public bool Displayed { get; set; }
    public ushort BrandId { get; set; }
    public IList<string> ImagesSrc { get; set; }
    public List<AddNewProductFeatures> Features { get; set; }
}