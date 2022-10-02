using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Shared;

namespace KalaMarket.Domain.Products.ProductAgg;

public class Category : BaseEntity<long>
{
    #region Properties
    public byte CategoryType { get; private set; }
    public string? ParentName { get; set; }
    public string? Name { get; private set; }
    public virtual Category? ParentCategory { get; set; }
    public long? ParentCategoryId { get; private set; }
    public virtual IList<Category> SubCategories { get; private set; }
    public virtual IList<Product> Products { get; private set; }
    #endregion

    #region Constructors

    protected Category()
    {
    }
    public Category(string name, byte categoryType = KalaMarketConstants.CategoryType.Category,
       long? parentCategoryId = null, string? parentName = null) : base()
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
        SubCategories = new List<Category>();
        Products = new List<Product>();
        CategoryType = categoryType;
        ParentName = parentName;
    }
    #endregion
    #region Methods
    public bool UpdateCategory(string name)
    {
        Name = name;
        UpdateTimes();
        return true;
    }
    public bool UpdateCategory(string name, long parentCategoryId, byte parentType, string? parentName = null)
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
        CategoryType = parentType;
        ParentName = parentName;
        UpdateTimes();
        return true;
    }
    #endregion
}