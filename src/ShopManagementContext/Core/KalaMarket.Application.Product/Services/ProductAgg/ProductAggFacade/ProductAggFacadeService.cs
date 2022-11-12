using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Implement;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.ProductAgg.Carts;
using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.ProductAgg.Common.Facade.implement;
using KalaMarket.Application.Product.Services.ProductAgg.Common.Facade.Interfaces;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.FacadePattern.Implement;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.FacadePattern.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;

public class ProductAggFacadeService : IProductAggFacadeService
{
    #region Constructor

    public ProductAggFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Fields

    private IProductFacadeService? _product;
    private IBrandFacade? _brand;
    private ICategoryFacade? _category;
    private ICommonProductAggService? _common;
    private ICartService? _cartService;

    #endregion /Fields

    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public IProductFacadeService Product => _product ??= new ProductFacadeService(Context, Logger);

    public ICartService CartService => _cartService ??= new CartService(Context, Logger);

    public IBrandFacade Brand => _brand ??= new BrandFacade(Context, Logger);

    public ICategoryFacade Category => _category ??= new CategoryFacade(Context, Logger);

    public ICommonProductAggService Common => _common ??= new CommonProductAggService(Context, Logger);

    #endregion
}