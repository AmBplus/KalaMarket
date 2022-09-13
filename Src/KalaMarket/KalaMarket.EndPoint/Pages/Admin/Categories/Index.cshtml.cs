using KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.EndPoint.Infrastructure;
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

        private ICategoryFacade _categoryFacade { get; }
        public void OnGet()
        {
           var result = _categoryFacade.CategoryQuery.GetAllParent.Execute(4);
        }
    }
}
