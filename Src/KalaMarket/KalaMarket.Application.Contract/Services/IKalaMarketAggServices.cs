using KalaMarket.Application.HomePage.HomePage.Facade;
using KalaMarket.Application.Product.Services.Products.ProductAggFacade;
using KalaMarket.Application.User.Services.Users.FacadePattern;

namespace KalaMarket.Application.Agg.Services;
/// <summary>
/// تمامی سرویس ها لایه اپلیکشن
/// </summary>
public interface IKalaMarketAggServices
{
    /// <summary>
    /// سرویس های مرتبط کاربر
    /// </summary>
    IUserAggFacadeService UserAggFacadeService { get; }
    /// <summary>
    /// سرویس های مرتبط کالا
    /// </summary>
    IProductAggFacadeService ProductAggFacadeService { get; }
    /// <summary>
    /// سرویس های مرتبط با صفحه اصلی
    /// </summary>
    IHomePageAggFacadeService HomePageAggFacadeService { get; }

}