using System.ComponentModel.DataAnnotations;
using KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.FacadePattern.Facade;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Filters.ModelState;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.EndPoint.Areas.Admin.Pages.Categories;

[ValidateModelRazorPage]
public class AddBrandModel : BasePageModel
{
    private ICategoryFacade _categoryFacade;

    public AddBrandModel(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    public void OnGet(long? parentCategoryId = null)
    {
        ParentId = parentCategoryId;
    }


    public IActionResult OnPost()
    {
        var result = _categoryFacade.CategoryCommand.AddCategoryService.Execute(new()
        {
            Name = Name,
            ParentCategoryId = ParentId
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

    #region Category Model

    [BindProperty] public long? ParentId { get; set; }

    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [StringLength(KalaMarketConstants.MaxLength.Name
        , MinimumLength = 1
        , ErrorMessageResourceType = typeof(ErrorMessages)
        , ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
    [BindProperty]
    public string Name { get; set; }

    #endregion /Category Model
}