using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategories;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Shared.Dto;

namespace KalaMarket.EndPoint.Pages.Admin.Brands
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
