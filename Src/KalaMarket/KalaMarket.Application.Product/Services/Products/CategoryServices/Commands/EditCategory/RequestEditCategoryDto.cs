using KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.AddNewCategory;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.EditCategory;

public class RequestEditCategoryDto : RequestAddNewCategoryDto
{
    public long id { get; set; }
}