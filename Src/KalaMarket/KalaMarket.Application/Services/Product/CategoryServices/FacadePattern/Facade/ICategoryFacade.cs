using KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.CommandFacade;
using KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.QueryFacade;

namespace KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.Facade;

public interface ICategoryFacade
{
    ICategoryCommandFacade  CategoryCommand { get; }
    ICategoryQueryFacade CategoryQuery { get; }
}