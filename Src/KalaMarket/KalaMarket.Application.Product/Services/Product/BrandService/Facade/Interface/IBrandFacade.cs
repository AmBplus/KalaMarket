namespace KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;

public interface IBrandFacade
{
    IBrandQueryFacade BrandQuery { get; }
    IBrandCmdFacade brandCmd { get;}
}