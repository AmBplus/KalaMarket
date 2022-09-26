namespace KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;

public interface IProductFacadeService
{
    IProductCommandFacade Cmd { get; }
    IProductQueryFacade Query { get; }
}