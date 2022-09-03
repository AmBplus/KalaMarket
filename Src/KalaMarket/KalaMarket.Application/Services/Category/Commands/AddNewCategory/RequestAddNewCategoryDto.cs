namespace KalaMarket.Application.Services.Category.Commands.AddNewCategory;

public class RequestAddNewCategoryDto
{
    public string Name { get; set; }
    public long? ParentCategoryId { get; set; }
}