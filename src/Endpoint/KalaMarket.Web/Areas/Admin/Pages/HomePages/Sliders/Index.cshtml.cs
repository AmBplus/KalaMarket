using KalaMarket.Application.Agg.Services;
using KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Areas.Admin.Pages.HomePages.Sliders;

public class IndexModel : BasePageModel
{
    public IndexModel(IKalaMarketAggServices kalaMarketServices)
    {
        KalaMarketServices = kalaMarketServices;
    }

    public ResultGetSlidersDto Result { get; set; }
    private IKalaMarketAggServices KalaMarketServices { get; }

    public async Task<IActionResult> OnGet([FromQuery] int? page = 1,
        [FromQuery] byte? pageSize = KalaMarketConstants.Page.PageSize)
    {
        var result = await KalaMarketServices.HomePageAggFacadeService.Slider.Query.GetSlidersService.ExecuteAsync(
            new RequestGetSlidersDto
            {
                Page = page < 1 ? 1 : (int)page,
                PageSize = pageSize < 0 ? KalaMarketConstants.Page.PageSize : (byte)pageSize
            });
        if (!result.IsSuccess) AddToastError(result.Message);
        Result = result.Data;
        return Page();
    }
}