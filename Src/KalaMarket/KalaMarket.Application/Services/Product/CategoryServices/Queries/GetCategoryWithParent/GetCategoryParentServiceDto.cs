using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategory;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithParent;

public class GetCategoryParentServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public GetCategoryServiceDto Parent { get; set; }
}