using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategory;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithChild;

public class GetCategoryChildServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public byte CategoryType { get; set; }
    public IEnumerable<GetCategoryServiceDto> ChildCategories { get; set; }
}