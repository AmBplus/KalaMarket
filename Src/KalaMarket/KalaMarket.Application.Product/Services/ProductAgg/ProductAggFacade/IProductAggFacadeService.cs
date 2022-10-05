using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.ProductAgg.Carts;
using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.ProductAgg.Common.Facade.Interfaces;
using KalaMarket.Application.Product.Services.ProductAgg.ProductService.FacadePattern.Interfaces;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductAggFacade;
/// <summary>
/// درخواست های مدل های مربوط به محصول
/// </summary>
public interface IProductAggFacadeService
{
    /// <summary>
    /// سرویس های محصول
    /// </summary>
    IProductFacadeService Product { get; }
    /// <summary>
    /// سرویس سبد خرید
    /// </summary>
    ICartService CartService { get; }
    /// <summary>
    /// سرویس های برند 
    /// </summary>
    IBrandFacade Brand { get; }
    /// <summary>
    ///  سرویس های دسته بندی
    /// </summary>
    ICategoryFacade Category { get; }
    /// <summary>
    /// درخواست های متدوال و مشترک
    /// </summary>
    ICommonProductAggService Common { get; }
}