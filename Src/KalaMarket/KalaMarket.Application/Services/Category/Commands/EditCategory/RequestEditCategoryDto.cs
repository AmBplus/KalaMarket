using KalaMarket.Application.Services.Category.Commands.AddNewCategory;

namespace KalaMarket.Application.Services.Category.Commands.EditCategory;

public class RequestEditCategoryDto  : RequestAddNewCategoryDto
{
    public long id { get; set; }
}