using KalaMarket.Application.Product.Services.Products.BrandService.Query.GetAll;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;

public interface IBrandQueryFacade
{
    IGetAllBrandService GetAll { get; }
}