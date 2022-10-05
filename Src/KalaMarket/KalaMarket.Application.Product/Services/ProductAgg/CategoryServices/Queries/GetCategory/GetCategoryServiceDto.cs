namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Queries.GetCategory;

public class GetCategoryServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool HasChild { get; set; }
    public string ParentName { get; set; }
    public byte Type { get; set; }
}