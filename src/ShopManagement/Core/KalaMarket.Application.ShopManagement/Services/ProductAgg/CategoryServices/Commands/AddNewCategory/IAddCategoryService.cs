using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.AddNewCategory;

public interface IAddCategoryService
{
    ResultDto Execute(RequestAddNewCategoryDto request);
}