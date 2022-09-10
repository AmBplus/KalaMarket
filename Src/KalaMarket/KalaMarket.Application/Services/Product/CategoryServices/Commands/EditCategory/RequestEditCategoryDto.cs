using KalaMarket.Application.Services.Product.CategoryServices.Commands.AddNewCategory;

namespace KalaMarket.Application.Services.Product.CategoryServices.Commands.EditCategory;

public class RequestEditCategoryDto  : RequestAddNewCategoryDto
{
    public long id { get; set; }
}