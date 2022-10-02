using KalaMarket.Application.Product.Services.Products.Common.Query.GetCategorySite;
using KalaMarket.Application.Product.Services.Products.Common.Query.GetMenuItemService;

namespace KalaMarket.Application.Product.Services.Products.Common.Facade.Interfaces;

public interface ICommonQueryProductAggService
{
    /// <summary>
    /// گرفتن منو سایت
    /// </summary>
    /// <returns></returns>
    IGetMenuItemService GetMenuItems { get; }
    /// <summary>
    /// گرفتن دسته بندی های اصلی سایت
    /// </summary>
    IGetCategorySiteService GetCategoriesSite { get; }
}