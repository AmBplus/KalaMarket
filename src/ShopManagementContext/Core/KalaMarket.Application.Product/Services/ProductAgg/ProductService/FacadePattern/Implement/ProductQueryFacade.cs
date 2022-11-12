using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.FacadePattern.Interfaces;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetDetailProductForAdmin;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductDetailForSite;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductForAdmin;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductsForAdmin;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductsForSite;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.FacadePattern.Implement;

internal class ProductQueryFacade : IProductQueryFacade
{
    #region Constructor

    public ProductQueryFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Fields

    private IGetProductForAdminService? _productForAdmin;
    private IGetProductsForAdminService? _productsForAdmin;
    private IGetDetailProductForAdminService? _detailProductForAdmin;
    private IGetProductsForSiteService? _productsForSite;
    private IGetProductDetailForSiteService? _productDetailForSite;

    #endregion /Fields

    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public IGetProductForAdminService ProductForAdmin =>
        _productForAdmin ??= new GetProductForAdminService(Context, Logger);

    public IGetProductsForAdminService ProductsForAdmin =>
        _productsForAdmin ??= new GetProductsForAdminService(Context, Logger);

    public IGetDetailProductForAdminService DetailProductForAdmin =>
        _detailProductForAdmin ??= new GetProductDetailForAdminService(Context, Logger);

    public IGetProductsForSiteService ProductsForSite =>
        _productsForSite ??= new GetProductsForSiteService(Context);

    public IGetProductDetailForSiteService ProductDetailForSite =>
        _productDetailForSite ??= new GetProductDetailForSiteService(Context, Logger);

    #endregion /Properties
}