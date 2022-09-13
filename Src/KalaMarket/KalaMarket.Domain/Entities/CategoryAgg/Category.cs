using KalaMarket.Domain.Entities.BaseEntities;
using KalaMarket.Shared;

namespace KalaMarket.Domain.Entities.CategoryAgg;

public class Category : BaseEntity<long>
{
    #region Properties
    public byte CategoryType { get;private set; }
    public string ParentName { get; set; }
    public string Name { get; private set; }
    public virtual Category ParentCategory { get; set; }
    public long? ParentCategoryId { get;private set; }
    public virtual IList<Category> SubCategories { get; private set; }
    #endregion

    #region Constructors

    protected Category()
    {
    }
    public Category(string name, long? parentCategoryId = null
        , byte categoryType = KalaMarketConstants.CategoryType.Category, string parentName = null) : base()
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
        ParentCategory = new Category();
        SubCategories = new List<Category>();
        CategoryType = categoryType;
        ParentName = parentName;
    }
    #endregion
    #region Methods
    public bool UpdateCategory(string name)
    {
        Name = name;
        base.UpdateTimes();
        return true;
    }
    public bool UpdateCategory(string name , long parentCategoryId , byte parentType , string? parentName = null)
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
        CategoryType = parentType;
        ParentName = parentName ; 
        base.UpdateTimes();
        return true;
    }
    #endregion
}