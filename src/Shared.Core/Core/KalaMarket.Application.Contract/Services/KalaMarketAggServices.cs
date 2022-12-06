using KalaMarket.Application.HomePage.HomePage.Facade;
using KalaMarket.Application.Identity.Services.Users.FacadePattern;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using KalaMarket.Shared;

namespace KalaMarket.Application.Agg.Services;

public class KalaMarketAggServices : IKalaMarketAggServices
{
    #region Constructor

    public KalaMarketAggServices(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    #endregion /Constructor

    #region Fields

    private IUserAggFacadeService? _userAggFacadeService;
    private IProductAggFacadeService? _productAggFacadeService;
    private IHomePageAggFacadeService? _homePageAggFacadeService;
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    #endregion /Fields

    #region Properties

    public IUserAggFacadeService UserAggFacadeService
        => _userAggFacadeService ??= new UserAggFacadeService(Context, Logger);

    public IProductAggFacadeService ProductAggFacadeService
        => _productAggFacadeService ??= new ProductAggFacadeService(Context, Logger);

    public IHomePageAggFacadeService HomePageAggFacadeService
        => _homePageAggFacadeService ??= new HomePageAggFacadeService(Context, Logger);

    #endregion /Properties
}