using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Command.Active;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Facade.Interface;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Query.Get;
using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Query.GetAll;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.EndPoint.Areas.Admin.Pages.Brands;

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
        var result = BrandFacade.brandCmd.ChangeActivation.Execute(new RequestChangeActivation
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