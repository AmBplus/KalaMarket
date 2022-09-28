using KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategory;

namespace KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategories;

public class GetCategoriesServiceDto
{
   public IList<GetCategoryServiceDto> _categories { get; set; }
   public int PageSize { get; set; }
   public int RowCount { get; set; }
   public int CurrentPage { get; set; }
}