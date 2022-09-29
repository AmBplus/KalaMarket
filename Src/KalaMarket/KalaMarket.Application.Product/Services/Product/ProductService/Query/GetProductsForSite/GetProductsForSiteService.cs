using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForSite;

public class GetProductsForSiteService : IGetProductsForSiteService
{

    private readonly IKalaMarketContext Context;
    public GetProductsForSiteService(IKalaMarketContext context)
    {
        Context = context;
    }
    public ResultDto<ResultGetProductsForSiteDto> Execute(RequestGetProductsForSiteDto request)
    {
        var result = new ResultDto<ResultGetProductsForSiteDto>(new ResultGetProductsForSiteDto());
        int totalRow = 0;
        var poducts = Context.Products
            .Include(p => p.Images);

        Random rd = new Random();
        result.Data = new ResultGetProductsForSiteDto
        {
            TotalRow = totalRow,
            Products = poducts.Select(p => new GetProductForSiteDto
            {
                Id = p.Id,
                Star = rd.Next(1, 5),
                Title = p.Name,
                ImageSrc = p.Images.FirstOrDefault().Src,
                Price = p.Price,
                Slug = p.Slug,
            }).ToPaged(request.Page, KalaMarketConstants.Page.PageSizeInWeb, out totalRow).ToList(),
        };
        result.IsSuccess = true;
        return result;
    }
}