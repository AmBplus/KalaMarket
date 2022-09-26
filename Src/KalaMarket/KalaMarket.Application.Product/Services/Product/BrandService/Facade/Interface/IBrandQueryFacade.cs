using KalaMarket.Application.Product.Services.Product.BrandService.Query.GetAll;

namespace KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;

public interface IBrandQueryFacade
{
    IGetAllBrandService GetAll { get; }
}