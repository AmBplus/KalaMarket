using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.CommandFacade;
using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.QueryFacade;

namespace KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.Facade;

public interface ICategoryFacade
{
    ICategoryCommandFacade CategoryCommand { get; }
    ICategoryQueryFacade CategoryQuery { get; }
}