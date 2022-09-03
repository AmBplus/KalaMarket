using KalaMarket.Domain.Entities.BaseEntities;

namespace KalaMarket.Domain.Entities.CategoryAgg;

public class Category : BaseEntity<long>
{
    #region Properties

    public string Name { get; private set; }
    public virtual Category ParentCategory { get;private set; }
    public long? ParentCategoryId { get; set; }
    public virtual IList<Category> SubCategories { get; private set; }

    #endregion

    #region Constructors

    protected Category()
    {
    }
    public Category(string name, long? parentCategoryId = null):base()
    {
        Name = name;
        ParentCategoryId = parentCategoryId;
        ParentCategory = new Category();
        SubCategories = new List<Category>();
    }

    #endregion

    #region Methods
    public bool SetParrentCategory(Category parrentCategory)
    {
        ParentCategory = parrentCategory;
        return true;
    }
    public bool UpdateCategory(string name)
    {
        Name = name;
        base.UpdateTimes();
        return true;
    }
    public bool UpdateCategory(string name , long parentCategoryId ,Category parentCategory )
    {
        Name = name;
        ParentCategory = parentCategory;
        ParentCategoryId = parentCategoryId;
        base.UpdateTimes();
        return true;
    }
    #endregion
}