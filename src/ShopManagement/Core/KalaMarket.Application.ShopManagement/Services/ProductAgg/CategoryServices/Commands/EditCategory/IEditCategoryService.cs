using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Commands.EditCategory;

public interface IEditCategoryService
{
    ResultDto Execute(RequestEditCategoryDto request);
}