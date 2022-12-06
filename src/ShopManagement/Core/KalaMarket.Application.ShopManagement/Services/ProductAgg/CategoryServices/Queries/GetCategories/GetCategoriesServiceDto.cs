using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategory;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategories;

public class GetCategoriesServiceDto
{
    public IList<GetCategoryServiceDto> _categories { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
}