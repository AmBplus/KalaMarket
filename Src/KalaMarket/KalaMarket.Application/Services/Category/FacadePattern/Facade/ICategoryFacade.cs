using KalaMarket.Application.Services.Category.FacadePattern.CommandFacade;
using KalaMarket.Application.Services.Category.FacadePattern.QueryFacade;

namespace KalaMarket.Application.Services.Category.FacadePattern.Facade;

public interface ICategoryFacade
{
    ICategoryCommandFacade  CategoryCommand { get; }
    ICategoryQueryFacade CategoryQuery { get; }
}