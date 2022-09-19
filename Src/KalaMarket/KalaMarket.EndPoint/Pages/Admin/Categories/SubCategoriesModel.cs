using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategory;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategoryWithChild;
using KalaMarket.EndPoint.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KalaMarket.EndPoint.Pages.Admin.Categories
{
    public class SubCategoriesModel : BasePageModel
    {
        private ICategoryFacade CategoryFacade { get; }
        public GetCategoryChildServiceDto CategoryServiceDto { get; set; }
        public SubCategoriesModel(ICategoryFacade categoryFacade)
        {
            CategoryFacade = categoryFacade;
        }

        public void OnGet(long id)
        {
           var result =  CategoryFacade.CategoryQuery.GetChild.Execute(id);
           if (!result.IsSuccess)
           {
               AddToastError(result.Message);
               // for null exception
               CategoryServiceDto = new GetCategoryChildServiceDto()
               {
                   ChildCategories = new List<GetCategoryServiceDto>()
               };
           }
           else
           {
               CategoryServiceDto = result.Data;
           }
        }
    }
}
