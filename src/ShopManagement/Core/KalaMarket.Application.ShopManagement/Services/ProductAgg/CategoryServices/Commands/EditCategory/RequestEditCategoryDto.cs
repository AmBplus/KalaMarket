using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.EditCategory;

public class RequestEditCategoryDto : RequestAddNewCategoryDto
{
    public long id { get; set; }
}