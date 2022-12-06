namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Facade.Interfaces;

public interface ICommonProductAggService
{
    /// <summary>
    ///     سرویس های درخواست کوئری
    /// </summary>
    ICommonQueryProductAggService Query { get; }

    /// <summary>
    ///     سرویس های ایجاد کامند
    /// </summary>
    ICommonQueryProductAggService Cmd { get; }
}