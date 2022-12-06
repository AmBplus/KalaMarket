using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductAggFacade;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductsForSite;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using Microsoft.AspNetCore.Mvc;
using Shared.AspNetCore.Infrastructure;

namespace KalaMarket.Web.Pages.Site.Products;

public class IndexModel : BasePageModel
{
    public IndexModel(IProductAggFacadeService productAggFacadeService)
    {
        ProductAggFacadeService = productAggFacadeService;
    }

    public ResultGetProductsForSiteDto ResultGetProducts { get; set; }
    private IProductAggFacadeService ProductAggFacadeService { get; }
    public int Page { get; set; } = 1;
    public byte PageSize { get; set; } = KalaMarketConstants.Page.PageSize;
    public string SearchKey { get; set; }
    public long? CategoryId { get; set; }
    public int TotalRecord { get; set; } = 1;
    public OrderingProduct Ordering { get; set; } = OrderingProduct.NotOrder;

    public async Task<IActionResult> OnGet([FromQuery] int page = 1,
        [FromQuery] byte pageSize = KalaMarketConstants.Page.PageSize, [FromQuery] string searchKey = null,
        [FromQuery] long? categoryId = null, OrderingProduct ordering = OrderingProduct.NotOrder)
    {
        var result = await ProductAggFacadeService.Product.Query.ProductsForSite.ExecuteAsync(
            new RequestGetProductsForSiteDto
            {
                Page = Page = page,
                CategoryId = CategoryId = categoryId,
                SearchKey = SearchKey = searchKey,
                PageSize = PageSize = pageSize,
                Order = Ordering = ordering
            });

        if (!result.IsSuccess) AddToastError(ErrorMessages.ProblemOccurred);
        ResultGetProducts = result.Data;
        TotalRecord = result.Data.TotalRow;
        return Page();
    }
}