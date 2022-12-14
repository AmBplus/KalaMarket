using System.ComponentModel.DataAnnotations;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Filters.ModelState;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Areas.Admin.Pages.Brands;

[ValidateModelRazorPage]
public class AddBrandModel : BasePageModel
{
    public AddBrandModel(IBrandFacade brandFacade)
    {
        BrandFacade = brandFacade;
    }

    private IBrandFacade BrandFacade { get; }

    #region Brand Model

    [BindProperty]
    [Display(ResourceType = typeof(PropertiesName), Name = nameof(PropertiesName.Name))]
    [Required(ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.RequiredWithFieldName))]
    [MaxLength(KalaMarketConstants.MaxLength.Name, ErrorMessageResourceType = typeof(ErrorMessages),
        ErrorMessageResourceName = nameof(ErrorMessages.MaxLen))]
    public string Name { get; set; }

    #endregion /Brand Model

    public void OnGet()
    {
    }


    public IActionResult OnPost()
    {
        var result = BrandFacade.brandCmd.AddBrandService.Execute(new()
        {
            Name = Name
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