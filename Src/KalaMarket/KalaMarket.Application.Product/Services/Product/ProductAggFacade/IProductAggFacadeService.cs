using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.Common.Facade.Interfaces;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;

namespace KalaMarket.Application.Product.Services.Product.ProductAggFacade;
/// <summary>
/// درخواست های مدل های مربوط به محصول
/// </summary>
public interface IProductAggFacadeService
{
    
    IProductFacadeService Product { get; }
    IBrandFacade Brand { get; }
    ICategoryFacade Category { get; }
    /// <summary>
    /// درخواست های متدوال و مشترک
    /// </summary>
    ICommonProductAggService  Common { get; }
}