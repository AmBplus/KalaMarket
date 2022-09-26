using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;

namespace KalaMarket.Application.Product.Services.Product.ProductAggFacade;

public interface IProductAggFacadeService
{
    IProductFacadeService Product { get; }
    IBrandFacade Brand { get; }
    ICategoryFacade Category { get; }
}