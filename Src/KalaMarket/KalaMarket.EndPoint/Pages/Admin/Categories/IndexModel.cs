using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategories;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Admin.Categories
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }
        public ResultDto<GetCategoriesServiceDto> Result { get; set; }
        private ICategoryFacade _categoryFacade { get; }
        public void OnGet()
        {
         Result = _categoryFacade.CategoryQuery.GetCategories.Execute();
            
        }
    }
}
