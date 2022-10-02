using KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategory;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategoryWithChild;

public class GetCategoryChildServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public byte CategoryType { get; set; }
    public IEnumerable<GetCategoryServiceDto> ChildCategories { get; set; }
}