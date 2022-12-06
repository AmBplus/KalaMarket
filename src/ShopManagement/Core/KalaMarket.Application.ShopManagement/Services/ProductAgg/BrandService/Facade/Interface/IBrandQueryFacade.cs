using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Query.GetAll;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Interface;

public interface IBrandQueryFacade
{
    IGetAllBrandService GetAll { get; }
}