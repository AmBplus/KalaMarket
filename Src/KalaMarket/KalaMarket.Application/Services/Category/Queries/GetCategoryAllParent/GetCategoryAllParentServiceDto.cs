using KalaMarket.Application.Services.Category.Queries.GetCategory;

namespace KalaMarket.Application.Services.Category.Queries.GetCategoryAllParent;

/// <summary>
/// Start From Ultimate Parent Category
/// </summary>
public class GetCategoryAllParentServiceDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    /// <summary>
    /// Child Category Until Reach Selected Category
    /// </summary>
    public GetCategoryAllParentServiceDto Child { get; set; }
    
}