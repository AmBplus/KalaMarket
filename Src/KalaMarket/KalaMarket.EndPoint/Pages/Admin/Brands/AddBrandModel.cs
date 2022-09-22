using System.ComponentModel.DataAnnotations;
using _01_Framework.AspCore.Filters.ModelState;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Pages.Admin.Brands;
[ValidateModelRazorPage]
public class AddBrandModel : BasePageModel
    {
        public AddBrandModel(IBrandFacade brandFacade)
        {
            BrandFacade = brandFacade;
        }

        public void OnGet()
        {
          
        }

        private IBrandFacade BrandFacade { get; }

        #region Brand Model
        
        [BindProperty]
        public string Name { get; set; }
    #endregion /Brand Model


    public IActionResult OnPost()
        {
            var result = BrandFacade.brandCmd.AddBrandService.Execute(new()
                {
                    Name = Name,
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
