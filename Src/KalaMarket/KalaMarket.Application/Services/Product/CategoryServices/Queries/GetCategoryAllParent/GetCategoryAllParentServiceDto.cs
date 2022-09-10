namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryAllParent;

/// <summary>
/// Start From Ultimate Parent Category
/// </summary>
public class GetCategoryAllParentServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long? ParentId { get; set; }
    public GetCategoryAllParentServiceDto Parent { get; set; }
    
}