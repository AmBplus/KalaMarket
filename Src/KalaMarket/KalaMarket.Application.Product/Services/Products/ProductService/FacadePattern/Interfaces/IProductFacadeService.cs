namespace KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Interfaces;

public interface IProductFacadeService
{
    IProductCommandFacade Cmd { get; }
    IProductQueryFacade Query { get; }
}