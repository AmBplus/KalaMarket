using KalaMarket.Shared;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;

public class RequestAddNewCategoryDto
{
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }
    public byte CategoryType { get; set; } = KalaMarketConstants.CategoryType.Category;
}