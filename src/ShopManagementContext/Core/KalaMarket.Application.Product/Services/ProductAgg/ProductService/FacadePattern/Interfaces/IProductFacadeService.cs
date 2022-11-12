namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.FacadePattern.Interfaces;

public interface IProductFacadeService
{
    IProductCommandFacade Cmd { get; }
    IProductQueryFacade Query { get; }
}