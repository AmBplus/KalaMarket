using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Products.Common.Facade.Interfaces;
using KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Interfaces;

namespace KalaMarket.Application.Product.Services.Products.ProductAggFacade;
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
    ICommonProductAggService Common { get; }
}