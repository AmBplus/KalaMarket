using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategory;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryAllParent;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithChild;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithParent;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithParentChild;

namespace KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.QueryFacade;

public class CategoryQueryFacade : ICategoryQueryFacade
{
    #region Fields

    private IGetCategoryService? _getCategoryService;
    private IGetCategoryChildService? _getCategoryWithChildService;
    private IGetCategoryWithParentChildService? _getCategoryWithParentChildService;
    private IGetCategoryParentService? _getCategoryWithParentService;
    private IGetCategoryAllParentService? _getAllParent;

    #endregion /Fields

    #region Constructor

    public CategoryQueryFacade(IKalaMarketContext context)
    {
        Context = context;
    }

    #endregion /Constructor

    #region Properties

    private IKalaMarketContext Context { get; }

    public IGetCategoryService GetCategory => _getCategoryService ??= new GetCategoryService(Context);

    public IGetCategoryChildService GetChild =>
        _getCategoryWithChildService ??= new GetCategoryChildService(Context);

    public IGetCategoryWithParentChildService GetParentAndChild =>
        _getCategoryWithParentChildService ??= new GetCategoryWithParentChildService(Context);

    public IGetCategoryParentService GetParent =>
        _getCategoryWithParentService ??=new GetCategoryParentService(Context);

    public IGetCategoryAllParentService GetAllParent => _getAllParent ?? new GetCategoryAllParentService(Context);

    #endregion /Properties
}