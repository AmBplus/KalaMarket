using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;
using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductForAdmin;
using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForAdmin;
using KalaMarket.Shared;

namespace KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Implement;

internal class ProductQueryFacade : IProductQueryFacade
{
    #region Fields

    private IGetProductForAdminService? _productForAdmin;
    private IGetProductsForAdminService? _productsForAdmin;

    #endregion /Fields

    #region Constructor
    public ProductQueryFacade(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    #endregion /Constructor
   
    #region Properties

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    /// <summary>
    /// دریافت محصول
    /// </summary>
    public IGetProductForAdminService ProductForAdmin
    {
        get => _productForAdmin ??= new GetProductForAdminService(Context,Logger);
    }
    /// <summary>
    /// دریافت محصولات
    /// </summary>
    public IGetProductsForAdminService ProductsForAdmin
    {
        get => _productsForAdmin ??= new GetProductsForAdminService(Context,Logger);
    }

    #endregion /Properties
}