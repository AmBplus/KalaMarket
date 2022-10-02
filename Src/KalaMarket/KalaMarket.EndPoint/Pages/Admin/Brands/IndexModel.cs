using KalaMarket.Application.Product.Services.Products.BrandService.Command.Active;
using KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.Products.BrandService.Query.Get;
using KalaMarket.Application.Product.Services.Products.BrandService.Query.GetAll;
using KalaMarket.EndPoint.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KalaMarket.EndPoint.Pages.Admin.Brands
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(IBrandFacade brandFacade)
        {
            BrandFacade = brandFacade;
        }
        public List<GetBrandServiceDto> Brands { get; set; }
        private IBrandFacade BrandFacade { get; }
        public void OnGet()
        {
            var result = BrandFacade.BrandQuery.GetAll.Execute(new RequestGetAllBrandDto());
            if (result.IsSuccess == false)
            {
                result.Data.Brands = new List<GetBrandServiceDto>();
                AddToastError(result.Message);
            }
            Brands = result.Data.Brands;
        }

        public IActionResult OnGetChangeActivation(ushort id)
        {

            var result = BrandFacade.brandCmd.ChangeActivation.Execute(new RequestChangeActivation()
            {
                Id = id
            });
            if (result.IsSuccess == false)
            {
                AddToastError(result.Message);
                return RedirectToPage();
            }
            AddToastSuccess(result.Message);
            return RedirectToPage();
        }

    }
}
