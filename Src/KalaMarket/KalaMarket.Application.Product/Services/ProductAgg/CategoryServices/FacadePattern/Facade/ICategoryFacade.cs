using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.CommandFacade;
using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.QueryFacade;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.Facade;

public interface ICategoryFacade
{
    ICategoryCommandFacade CategoryCommand { get; }
    ICategoryQueryFacade CategoryQuery { get; }
}