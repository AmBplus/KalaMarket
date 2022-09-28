using System.ComponentModel.DataAnnotations;
using _01_Framework.AspCore.Utility;
using _01_Framework.AspCore.ValidateAttribute;
using KalaMarket.Application.Product.Services.Product.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Product.BrandService.Query.GetAll;
using KalaMarket.Application.Product.Services.Product.CategoryServices.FacadePattern.Facade;
using KalaMarket.Application.Product.Services.Product.CategoryServices.Queries.GetCategories;
using KalaMarket.Application.Product.Services.Product.ProductService.Commands.AddProduct;
using KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;
using KalaMarket.EndPoint.Infrastructure;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace KalaMarket.EndPoint.Pages.Admin.Products
{

    
    [BindProperties]
    public class AddProductModel : BasePageModel
    {
        public AddProductModel(ICategoryFacade categoryFacade, IBrandFacade brandFacade)
        {
            CategoryFacade = categoryFacade;
            BrandFacade = brandFacade;
        }
        private IBrandFacade BrandFacade { get; }
        private ICategoryFacade CategoryFacade { get; }
        [ValidateNever]
        [BindNever]
        public List<SelectListItem> Categories { get;private set; }
        [ValidateNever]
        [BindNever]
        public SelectList Brand { get; set; }
        #region Model

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; } = true;
        [Range(minimum:1,maximum:ushort.MaxValue,ErrorMessageResourceType = typeof(ErrorMessages)
            ,ErrorMessageResourceName = nameof(ErrorMessages.OutofMinMax))]
        public ushort BrandId { get; set; }
        [FileAcceptExtensions(new[] {KalaMarketConstants.ImageExtension.Jpg
            ,KalaMarketConstants.ImageExtension.Jpeg,
            KalaMarketConstants.ImageExtension.Png,
            KalaMarketConstants.ImageExtension.Webp
        })]
        public IList<IFormFile> Images { get; set; }
        public IList<AddNewProductFeatures> Features { get; set; }
        #endregion
        public void OnGet()
        {
            SetCategoriesList();
            SetBrandList();
        }
    
        public async Task<IActionResult> OnPost([FromServices] IHostingEnvironment hostEnvironment, [FromServices] IProductFacadeService productFacadeService)
        {
            if (!ModelState.IsValid)
            {
                SetCategoriesList();
                SetBrandList();
                return Page();
            }
            // Save Image File And Get Path
            IList<string> imagePath =
                await Images.SaveRangeFormFile(hostEnvironment, KalaMarketConstants.FolderPath.ProductPath);
            // Add Product And Get Result
            var result = productFacadeService.Cmd.Add.Execute(new RequestAddProductDto()
            {
                BrandId = BrandId,
                CategoryId = CategoryId,
                Description = Description,
                Displayed = Displayed,
                Features = Features,
                ImagesSrc = imagePath,
                Inventory = Inventory,
                Name = Name,
                Price = Price,
            });
            if (!result.IsSuccess)
            {
                // Remove Images
                 await  RemoveFileHelper.RemoveRangeFiles(hostEnvironment, imagePath);
                 AddToastError(result.Message);
            }
            else
            {
                AddToastSuccess(result.Message);
            }
            return RedirectToPage();
        }
         
        private void SetCategoriesList()
        {
            Categories = new List<SelectListItem>() { };
            // Get Categories
            var result =
                CategoryFacade.CategoryQuery.GetCategories.Execute(new RequestGetCategoriesDto()
                {
                    Type = KalaMarketConstants.CategoryType.SubCategory
                });
            
            if (!result.IsSuccess)
            {
                AddToastError(ErrorMessages.ProblemOccurred);
                return;
            }
            // Split By ParentName
            var groupByParentCategory = result.Data._categories.Select
            (x => new
            {
                x.Id,
                x.Name,
                x.ParentName
            }).GroupBy(x => x.ParentName);
            // Create SelectList Item By Name , Id And Grouped By ParentName 
            foreach (var group in groupByParentCategory)
            {
                // Create SelectListGroup By Parent Name Group
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
        private void SetBrandList()
        {
            
            var result =
                BrandFacade.BrandQuery.GetAll.Execute(new RequestGetAllBrandDto(){GetActiveBrand = true});
            if (!result.IsSuccess)
            {
                Brand = new SelectList(null);
                AddToastError(ErrorMessages.ProblemOccurred);
                return;
            }

            Brand = new SelectList(result.Data.Brands, "Id", "Name");
            
        }
    }
}
