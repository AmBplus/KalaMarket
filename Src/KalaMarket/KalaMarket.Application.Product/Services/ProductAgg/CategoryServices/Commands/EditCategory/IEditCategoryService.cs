using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.EditCategory;

public interface IEditCategoryService
{
    ResultDto Execute(RequestEditCategoryDto request);
}