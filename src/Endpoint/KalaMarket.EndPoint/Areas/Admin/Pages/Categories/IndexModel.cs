using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Queries.GetCategories;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.EndPoint.Areas.Admin.Pages.Categories;

public class IndexModel : BasePageModel
{
    public IndexModel(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    public ResultDto<GetCategoriesServiceDto> Result { get; set; }
    private ICategoryFacade _categoryFacade { get; }

    public void OnGet([FromQuery] int page = 1, [FromQuery] byte pageSize = KalaMarketConstants.Page.PageSize)
    {
        Result = _categoryFacade.CategoryQuery.GetCategories.Execute(new RequestGetCategoriesDto
        {
            Page = page,
            PageSize = pageSize
        });
    }
}