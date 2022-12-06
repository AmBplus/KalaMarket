namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Interface;

public interface IBrandFacade
{
    IBrandQueryFacade BrandQuery { get; }
    IBrandCmdFacade brandCmd { get; }
}