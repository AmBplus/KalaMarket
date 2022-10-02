using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategory;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategoryWithParent;

public class GetCategoryParentServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public GetCategoryServiceDto Parent { get; set; }
}