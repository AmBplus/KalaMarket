namespace KalaMarket.Application.Services.Product.CategoryServices.Commands.AddNewCategory;

public class RequestAddNewCategoryDto
{
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }
}