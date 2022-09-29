using KalaMarket.Application.Product.Services.Product.Common.Query.GetMenuItemService;

namespace KalaMarket.Application.Product.Services.Product.Common.Facade.Interfaces;

public interface ICommonQueryProductAggService
{
    /// <summary>
    /// گرفتن منو سایت
    /// </summary>
    /// <returns></returns>
    IGetMenuItemService GetMenuItems { get; }
}