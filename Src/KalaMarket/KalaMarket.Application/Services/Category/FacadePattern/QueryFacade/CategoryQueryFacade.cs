using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Category.Queries.GetCategory;
using KalaMarket.Application.Services.Category.Queries.GetCategoryWithChild;
using KalaMarket.Application.Services.Category.Queries.GetCategoryWithParent;
using KalaMarket.Application.Services.Category.Queries.GetCategoryWithParentChild;

namespace KalaMarket.Application.Services.Category.FacadePattern.QueryFacade;

public class CategoryQueryFacade : ICategoryQueryFacade
{
    #region Fields

    private IGetCategoryService? _getCategoryService;
    private IGetCategoryWithChildService? _getCategoryWithChildService;
    private IGetCategoryWithParentChildService? _getCategoryWithParentChildService;
    private IGetCategoryWithParentService? _getCategoryWithParentService;

    #endregion /Fields

    #region Constructor

    public CategoryQueryFacade(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Constructor

    #region Properties

    private IKalaMarketContext Context { get; }

    public IGetCategoryService GetCategoryService => _getCategoryService ??= new GetCategoryService(Context);

    public IGetCategoryWithChildService GetCategoryWithChildService =>
        _getCategoryWithChildService ??= new GetCategoryWithChildService(Context);

    public IGetCategoryWithParentChildService GetCategoryWithParentChildService =>
        _getCategoryWithParentChildService ??= new GetCategoryWithParentChildService(Context);

    public IGetCategoryWithParentService GetCategoryWithParentService =>
        _getCategoryWithParentService ??=new GetCategoryWithParentService(Context);

    #endregion /Properties
}