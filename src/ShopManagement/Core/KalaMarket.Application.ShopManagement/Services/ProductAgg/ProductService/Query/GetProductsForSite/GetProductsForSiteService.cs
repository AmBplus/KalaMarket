﻿using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductsForSite;

public class GetProductsForSiteService : IGetProductsForSiteService
{
    private readonly IKalaMarketContext Context;

    public GetProductsForSiteService(IKalaMarketContext context)
    {
        result = new ResultDto<ResultGetProductsForSiteDto>(new ResultGetProductsForSiteDto());
        Context = context;
    }

    private ResultDto<ResultGetProductsForSiteDto> result { get; }

    public ResultDto<ResultGetProductsForSiteDto> Execute(RequestGetProductsForSiteDto request)
    {
        result.Data.Products = SelectAndPagination(GenerateQuery(request), request.Page, request.PageSize).ToList();
        return result;
    }

    public async Task<ResultDto<ResultGetProductsForSiteDto>> ExecuteAsync(RequestGetProductsForSiteDto request)
    {
        result.Data.Products =
            await SelectAndPagination(GenerateQuery(request), request.Page, request.PageSize).ToListAsync();
        return result;
    }

    private IQueryable<GetProductForSiteDto> SelectAndPagination(IQueryable<Product> query,
        int page, byte pageSize)
    {
        var totalRow = 0;
        var result = SelectListProductDto(query)
            .ToPaged(page, pageSize, out totalRow);
        GenerateSucessResult(totalRow);
        return result;
    }

    private void GenerateSucessResult(int totalRow)
    {
        result.Data.TotalRow = totalRow;
        result.IsSuccess = true;
        result.Message = Messages.OperationDoneSuccessfully;
    }

    private IQueryable<Product> GenerateQuery(RequestGetProductsForSiteDto request)
    {
        var query = GenerateQueryIncludeImage();
        query = WhereCategoryIdIsNotNull(query, request.CategoryId);
        query = OrderBy(query, request.Order);
        query = WhereSearchKeyNotNull(query, request.SearchKey).AsNoTracking();
        return query;
    }

    private IQueryable<Product> WhereSearchKeyNotNull(
        IQueryable<Product> query, string? requestSearchKey)
    {
        if (!string.IsNullOrWhiteSpace(requestSearchKey))
            return query.Include(x => x.Category).Include(x => x.Brand)
                .Where(x => x.Name.Contains(requestSearchKey)
                            || x.Category.Name.Contains(requestSearchKey)
                            || x.Brand.Name.Contains(requestSearchKey));
        return query;
    }

    private IQueryable<GetProductForSiteDto> SelectListProductDto(IQueryable<Product> query)
    {
        var rd = new Random();
        return query
            .Select(x =>
                new GetProductForSiteDto
                {
                    Id = x.Id,
                    Star = rd.Next(1, 5),
                    Title = x.Name,
                    ImageSrc = x.Images.FirstOrDefault().Src,
                    Price = x.Price,
                    Slug = x.Slug
                });
    }

    private IQueryable<Product> GenerateQueryIncludeImage()
    {
        return Context.Products
            .Include(p => p.Images).AsQueryable();
    }

    private IQueryable<Product> WhereCategoryIdIsNotNull(
        IQueryable<Product> query, long? categoryId)
    {
        if (categoryId != null && categoryId != 0)
            return query.Include(x => x.Category)
                .Where(x => x.Category.Id == categoryId || x.Category.Id == categoryId);
        return query;
    }

    private IQueryable<Product> OrderBy(IQueryable<Product> query,
        OrderingProduct order)
    {
        switch (order)
        {
            case OrderingProduct.BestSelling:
            {
                break;
            }
            case OrderingProduct.MostPopular:
            {
                query = query.OrderByDescending(x => x.ViewCount);
                break;
            }
            case OrderingProduct.MostVisited:
            {
                query = query.OrderByDescending(x => x.ViewCount);
                break;
            }
            case OrderingProduct.Cheapest:
            {
                query = query.OrderBy(x => x.Price);
                break;
            }
            case OrderingProduct.TheMostExpensive:
            {
                query = query.OrderByDescending(x => x.Price);
                break;
            }
            case OrderingProduct.TheNewest:
            case OrderingProduct.NotOrder:
            default:
            {
                query = query.OrderByDescending(x => x.Id);
                break;
            }
        }

        return query;
    }
}