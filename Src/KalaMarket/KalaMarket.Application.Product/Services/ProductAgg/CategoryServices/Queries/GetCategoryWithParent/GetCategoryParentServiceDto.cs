using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Queries.GetCategory;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithParent;

public class GetCategoryParentServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public GetCategoryServiceDto Parent { get; set; }
}