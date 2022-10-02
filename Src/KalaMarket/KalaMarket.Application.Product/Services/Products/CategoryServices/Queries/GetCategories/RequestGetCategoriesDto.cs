namespace KalaMarket.Application.Product.Services.Products.CategoryServices.Queries.GetCategories;

public class RequestGetCategoriesDto
{
    public byte? Type { get; set; } = null;
    public int Page { get; set; } = 0;
    public byte PageSize { get; set; } = 0;
}