using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetCategorySite;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetMenuItemService;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Facade.Interfaces;

public interface ICommonQueryProductAggService
{
    /// <summary>
    ///     گرفتن منو سایت
    /// </summary>
    /// <returns></returns>
    IGetMenuItemService GetMenuItems { get; }

    /// <summary>
    ///     گرفتن دسته بندی های اصلی سایت
    /// </summary>
    IGetCategorySiteService GetCategoriesSite { get; }
}