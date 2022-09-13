namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithAllParent;

public class GetCategoryWithAllParentServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long? ParentId { get; set; }
    public byte? CategoryType { get; set; }
    public GetCategoryWithAllParentServiceDto Parent { get; set; }
}