namespace KalaMarket.Application.Product.Services.ProductAgg.Common.Query.GetMenuItemService;

public class GetMenuItemDto
{
    public long CategoryId { get; set; }
    public string Name { get; set; }
    public IEnumerable<GetMenuItemDto> Child { get; set; }
}