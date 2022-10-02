using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.AddNewCategory;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.EditCategory;
using KalaMarket.Application.Product.Services.Products.CategoryServices.Commands.RemoveCategory;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.CommandFacade;

public class CategoryCommandFacade : ICategoryCommandFacade
{
    #region Fields

    private IEditCategoryService? _editCategoryService;
    private IRemoveCategoryService? _removeCategoryService;
    private IAddCategoryService? _addCategoryService;

    #endregion /Fields

    #region Constructor

    public CategoryCommandFacade(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Constructor

    #region Properties

    private IKalaMarketContext Context { get; }

    public IEditCategoryService EditCategoryService => _editCategoryService ??= new EditCategoryService(Context);

    public IRemoveCategoryService RemoveCategoryService =>
        _removeCategoryService ??= new RemoveCategoryService(Context);

    public IAddCategoryService AddCategoryService => _addCategoryService ??= new AddCategoryService(Context);

    #endregion
}