using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Query.GetAll;

namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Interface;

public interface IBrandQueryFacade
{
    IGetAllBrandService GetAll { get; }
}