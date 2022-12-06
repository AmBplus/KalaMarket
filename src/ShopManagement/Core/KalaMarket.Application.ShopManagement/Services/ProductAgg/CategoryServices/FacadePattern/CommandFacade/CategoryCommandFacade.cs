using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.EditCategory;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.RemoveCategory;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.FacadePattern.CommandFacade;

public class CategoryCommandFacade : ICategoryCommandFacade
{
    #region Constructor

    public CategoryCommandFacade(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Constructor

    #region Fields

    private IEditCategoryService? _editCategoryService;
    private IRemoveCategoryService? _removeCategoryService;
    private IAddCategoryService? _addCategoryService;

    #endregion /Fields

    #region Properties

    private IKalaMarketContext Context { get; }

    public IEditCategoryService EditCategoryService => _editCategoryService ??= new EditCategoryService(Context);

    public IRemoveCategoryService RemoveCategoryService =>
        _removeCategoryService ??= new RemoveCategoryService(Context);

    public IAddCategoryService AddCategoryService => _addCategoryService ??= new AddCategoryService(Context);

    #endregion
}