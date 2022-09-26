using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;
using KalaMarket.Shared;
using Microsoft.Extensions.Logging;

namespace KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Implement;

public class ProductFacadeService : IProductFacadeService
{
    #region Constructor

    public ProductFacadeService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Fields


    private IProductCommandFacade? _cmd;
    private IProductQueryFacade? _query;

    #endregion Fields

    #region Properties
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public IProductCommandFacade Cmd => _cmd ?? new ProductCommandFacade(Context,Logger);

    public IProductQueryFacade Query => _query ?? new ProductQueryFacade(Context, Logger);

    #endregion /Properties
}