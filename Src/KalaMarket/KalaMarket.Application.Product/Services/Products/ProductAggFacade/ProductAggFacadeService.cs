using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Implement;
using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Products.Common.Facade.implement;
using KalaMarket.Application.Product.Services.Products.Common.Facade.Interfaces;
using KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Implement;
using KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Products.ProductAggFacade;

public class ProductAggFacadeService : IProductAggFacadeService
{
    #region Fields

    private IProductFacadeService? _product;
    private IBrandFacade? _brand;
    private ICategoryFacade? _category;
    private ICommonProductAggService? _common;

    #endregion /Fields

    #region Constructor

    public ProductAggFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public IProductFacadeService Product => _product ??= new ProductFacadeService(Context, Logger);

    public IBrandFacade Brand => _brand ??= new BrandFacade(Context, Logger);

    public ICategoryFacade Category => _category ??= new CategoryFacade(Context, Logger);

    public ICommonProductAggService Common => _common ??= new CommonProductAggService(Context, Logger);

    #endregion
}