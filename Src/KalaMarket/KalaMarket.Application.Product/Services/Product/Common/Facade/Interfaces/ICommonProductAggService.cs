namespace KalaMarket.Application.Product.Services.Product.Common.Facade.Interfaces;

public interface ICommonProductAggService
{
    /// <summary>
    /// سرویس های درخواست کوئری
    /// </summary>
    ICommonQueryProductAggService Query { get; }
    /// <summary>
    /// سرویس های ایجاد کامند
    /// </summary>
    ICommonQueryProductAggService Cmd { get; }
}