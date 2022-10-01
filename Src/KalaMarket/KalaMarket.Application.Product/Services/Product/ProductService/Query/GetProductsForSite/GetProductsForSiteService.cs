using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForSite;

public class GetProductsForSiteService : IGetProductsForSiteService
{

    private readonly IKalaMarketContext Context;
    private ResultDto<ResultGetProductsForSiteDto> result { get; }
    public GetProductsForSiteService(IKalaMarketContext context)
    {
        result = new ResultDto<ResultGetProductsForSiteDto>(new ResultGetProductsForSiteDto());
        Context = context;
    }
    public ResultDto<ResultGetProductsForSiteDto> Execute(RequestGetProductsForSiteDto request)
    {
        result.Data.Products = SelectAndPagination(GenerateQuery(request), request.Page).ToList();
        return result;
    }
    public async Task<ResultDto<ResultGetProductsForSiteDto>> ExecuteAsync(RequestGetProductsForSiteDto request)
    {
        result.Data.Products = await SelectAndPagination(GenerateQuery(request), request.Page).ToListAsync();
        return result;
    }

    private IQueryable<GetProductForSiteDto> SelectAndPagination(IQueryable<Domain.Entities.ProductAgg.Product> query, int page)
    {
        int totalRow = 0;
        var result = SelectListProductDto(query)
            .ToPaged(page, KalaMarketConstants.Page.PageSizeInWeb, out totalRow);
        GenerateSucessResult(totalRow);
        return result;
    }
    private void GenerateSucessResult(int totalRow)
    {
        result.Data.TotalRow = totalRow;
        result.IsSuccess = true;
        result.Message = Messages.OperationDoneSuccessfully;
    }
    private IQueryable<Domain.Entities.ProductAgg.Product> GenerateQuery(RequestGetProductsForSiteDto request)
    {
        var query = GenerateQueryIncludeImage();
        query = WhereCategoryIdIsNotNull(query, request.CategoryId);
        query = WhereSearchKeyNotNull(query, request.SearchKey).AsNoTracking();
        return query;
    }

    private IQueryable<Domain.Entities.ProductAgg.Product> WhereSearchKeyNotNull(IQueryable<Domain.Entities.ProductAgg.Product> query, string? requestSearchKey)
    {
        if (!string.IsNullOrWhiteSpace(requestSearchKey))
        {
            return query.Include(x => x.Category).Include(x => x.Brand)
                .Where(x => x.Name.Contains(requestSearchKey)
                            || x.Category.Name.Contains(requestSearchKey)
                            || x.Brand.Name.Contains(requestSearchKey));
        }
        return query;
    }

    private IQueryable<GetProductForSiteDto> SelectListProductDto(IQueryable<Domain.Entities.ProductAgg.Product> query)
    {
        Random rd = new Random();
        return query
            .Select(x =>
           new GetProductForSiteDto
           {
               Id = x.Id,
               Star = rd.Next(1, 5),
               Title = x.Name,
               ImageSrc = x.Images.FirstOrDefault().Src,
               Price = x.Price,
               Slug = x.Slug,
           });
    }
    private IQueryable<Domain.Entities.ProductAgg.Product> GenerateQueryIncludeImage()
    {
        return Context.Products
            .Include(p => p.Images).AsQueryable();
    }
    private IQueryable<Domain.Entities.ProductAgg.Product> WhereCategoryIdIsNotNull(IQueryable<Domain.Entities.ProductAgg.Product> query, long? categoryId)
    {
        if (categoryId != null && categoryId!=0)
        {
            return query.Include(x => x.Category).Where(x => x.Category.Id == categoryId || x.Category.Id == categoryId);
        }
        return query;
    }
}