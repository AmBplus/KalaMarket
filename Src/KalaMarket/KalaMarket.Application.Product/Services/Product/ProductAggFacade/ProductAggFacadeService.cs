using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Implement;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Implement;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.ProductAggFacade;

public class ProductAggFacadeService : IProductAggFacadeService
{
    #region Fields

    private IProductFacadeService? _product;
    private IBrandFacade? _brand;
    private ICategoryFacade? _category;

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

    public IProductFacadeService Product => _product ??= new ProductFacadeService(Context,Logger);

    public IBrandFacade Brand => _brand ??= new BrandFacade(Context,Logger);

    public ICategoryFacade Category => _category ??= new CategoryFacade(Context,Logger);

    #endregion
}