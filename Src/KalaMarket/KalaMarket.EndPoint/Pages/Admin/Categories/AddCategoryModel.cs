using _01_Framework.AspCore.Filters.ModelState;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using KalaMarket.Application.Product.Services.Products.CategoryServices.FacadePattern.Facade;


namespace KalaMarket.EndPoint.Pages.Admin.Categories;
[ValidateModelRazorPage]
public class AddBrandModel : BasePageModel
{
    public AddBrandModel(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    public void OnGet(long? parentCategoryId = null)
    {
        ParentId = parentCategoryId;
    }

    private ICategoryFacade _categoryFacade;

    #region Category Model
    [BindProperty]
    public long? ParentId { get; set; }
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [StringLength(maximumLength: KalaMarketConstants.MaxLength.Name
        , MinimumLength = 1
        , ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
    [BindProperty]
    public string Name { get; set; }
    #endregion /Category Model


    public IActionResult OnPost()
    {
        var result = _categoryFacade.CategoryCommand.AddCategoryService.Execute(new()
        {
            Name = Name,
            ParentCategoryId = ParentId,
        });
        // Check Result 
        if (!result.IsSuccess)
        {
            AddToastError(result.Message);
            return Page();
        }
        AddToastSuccess(result.Message);
        return RedirectToPage("index");
    }
}
