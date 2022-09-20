using System.Text.RegularExpressions;
using _01_Framework.AspCore.CheckContentType;
using _01_Framework.AspCore.Utility;
using _01_Framework.AspCore.ValidateAttribute;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategories;
using KalaMarket.Application.Product.Services.Product.ProductService.Commands.AddProduct;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.EndPoint.Infrastructure.Binder;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KalaMarket.EndPoint.Pages.Admin.Products
{

    //[ValidateModelRazorPage]
    [BindProperties]
    public class AddProductModel : BasePageModel
    {
        public AddProductModel(ICategoryFacade categoryFacade)
        {
            CategoryFacade = categoryFacade;
        }

        private ICategoryFacade CategoryFacade { get; }
        [ValidateNever]
        public List<SelectListItem> Categories { get;private set; }
        //[ValidateNever]
        //private SelectList Brand { get; set; }
        #region Model
      
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; } = true;
        public ushort? BrandId { get; set; }
        [FileAcceptExtensions(new[] {KalaMarketConstants.ImageExtension.Jpg
            ,KalaMarketConstants.ImageExtension.Jpeg,
            KalaMarketConstants.ImageExtension.Png,
            KalaMarketConstants.ImageExtension.Webp
        })]
        public ICollection<IFormFile> Images { get; set; }
        public List<AddNewProductFeatures> Features { get; set; }
        #endregion
        public void OnGet()
        {
            Categories = new List<SelectListItem>() { };
            var result =
                CategoryFacade.CategoryQuery.GetCategories.Execute(KalaMarketConstants.CategoryType.SubCategory);
            if (result.IsSuccess)
            { 
                SetCategoriesList(result);
            }
            else
            {
                AddToastError(ErrorMessages.ProblemOccurred);
            }
             
        }

        public async Task<IActionResult> OnPost([FromServices] IWebHostEnvironment hostEnvironment)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            //if (Image.FileIsValidImage())
            //{
            //    var extension = Path.GetExtension(Image.FileName);
            //    var fileName =await Image.SaveFormFile(
            //        Path.Combine(hostEnvironment.WebRootPath, KalaMarketConstants.FolderPath.ProductPath), extension);
            //}
            return RedirectToPage();
        }

        private void SetCategoriesList(ResultDto<GetCategoriesServiceDto> resultDto)
        {
            var groupByParentCategory = resultDto.Data._categories.Select(x => new
            {
                x.Id,
                x.Name,
                x.ParentName
            }).GroupBy(x => x.ParentName);
            foreach (var group in groupByParentCategory)
            {
                var categoryGroup = new SelectListGroup { Name = group.Key };
                foreach (var category in group)
                {
                    Categories.Add(new SelectListItem()
                    {
                        Value = category.Id.ToString(),
                        Group = categoryGroup,
                        Text = category.Name
                    });
                }
            }
        }
    }
}
