namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Interface;

public interface IBrandFacade
{
    IBrandQueryFacade BrandQuery { get; }
    IBrandCmdFacade brandCmd { get; }
}