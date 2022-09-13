using System.ComponentModel.DataAnnotations;
using KalaMarket.Application.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;


namespace KalaMarket.EndPoint.Pages.Admin.Categories
{
    public class AddCategoryModel : BasePageModel
    {
        public AddCategoryModel(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        public void OnGet(long? parentCateory)
        {
            ParentId = parentCateory;
        }
        private ICategoryFacade _categoryFacade;
        [BindProperty]
        [Range(0,Int64.MaxValue,ErrorMessageResourceType 
            = typeof(ErrorMessages),ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
        public long? ParentId { get; set; }
        [Display(ResourceType = typeof(PropertiesName),Name = nameof(PropertiesName.Name))]
        [StringLength(maximumLength: KalaMarketConstants.MaxLength.Name
            , MinimumLength = 1
            , ErrorMessageResourceType = typeof(ErrorMessages)
            , ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
        [BindProperty]
        public string Name { get; set; }

        public async Task<IActionResult> OnPost()
        {
            string message = String.Empty;
            if(!ModelState.IsValid)
            {
                foreach (var modelSateEntry in ModelState.Values)
                {
                    foreach (var error in modelSateEntry.Errors)
                    {
                        AddToastError(error.ErrorMessage);
                    }
                }
                return new JsonResult(new { message, IsSuccess = false });
            }
            // Add Category
            var result = _categoryFacade.CategoryCommand.AddCategoryService.Execute(new()
            {
                Name = Name,
                ParentCategoryId = ParentId,
            });
            // Check Result 
            if (!result.IsSuccess)
            {
                return new BadRequestObjectResult(new { message = result.Message, isSuccess = false });
            }
            return new JsonResult(new { message = result.Message, isSuccess = false });
        }
    }
}
