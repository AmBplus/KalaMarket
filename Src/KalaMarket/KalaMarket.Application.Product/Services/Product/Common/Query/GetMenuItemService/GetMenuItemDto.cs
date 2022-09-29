namespace KalaMarket.Application.Product.Services.Product.Common.Query.GetMenuItemService;

public class GetMenuItemDto
{
    public long CategoryId { get; set; }
    public string Name { get; set; }
    public IEnumerable<GetMenuItemDto> Child  { get; set; }
}