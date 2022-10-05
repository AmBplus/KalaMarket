using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.EditCategory;

public class RequestEditCategoryDto : RequestAddNewCategoryDto
{
    public long id { get; set; }
}