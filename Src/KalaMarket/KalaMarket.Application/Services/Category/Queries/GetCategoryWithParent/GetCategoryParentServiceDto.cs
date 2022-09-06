using KalaMarket.Application.Services.Category.Queries.GetCategory;

namespace KalaMarket.Application.Services.Category.Queries.GetCategoryWithParent;

public class GetCategoryParentServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public GetCategoryServiceDto Parent { get; set; }
}