﻿using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductDetailForSite;

public class GetProductDetailForSiteService : IGetProductDetailForSiteService
{
    public GetProductDetailForSiteService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        Result = new ResultDto<ProductDetailForSiteDto>(new ProductDetailForSiteDto());
    }

    private IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }
    private ResultDto<ProductDetailForSiteDto> Result { get; }

    public ResultDto<ProductDetailForSiteDto> Execute(RequestGetDetailProductForSiteDto request)
    {
        var product = GenerateQueryForProduct(request.Id).FirstOrDefault();
        IncreaseViewCount(product);
        if (CheckIsNullProduct(product!)) return Result;
        return SetResult(product);
    }

    public async Task<ResultDto<ProductDetailForSiteDto>> ExecuteAsync(RequestGetDetailProductForSiteDto request)
    {
        var product = await GenerateQueryForProduct(request.Id).FirstOrDefaultAsync();
        if (CheckIsNullProduct(product!)) return Result;
        await IncreaseViewCountAsync(product);
        return SetResult(product);
    }

    private ResultDto<ProductDetailForSiteDto> SetResult(Product product)
    {
        Result.Data = MapToDto(product!);
        Result.IsSuccess = true;
        Result.Message = Messages.OperationDoneSuccessfully;
        return Result;
    }


    private void IncreaseViewCount(Product product)
    {
        product.IncreaseViewCount();
        Context.SaveChanges();
    }

    private async Task IncreaseViewCountAsync(Product product)
    {
        product.IncreaseViewCount();
        await Context.SaveChangesAsync();
    }

    private bool CheckIsNullProduct(Product product)
    {
        if (product != null) return false;
        var message = string.Format(ErrorMessages.NotFind, nameof(Product));
        Logger.LogError(new NullReferenceException(message), message);
        Result.Message = message;
        return true;
    }

    private ProductDetailForSiteDto MapToDto(Product product)
    {
        return new ProductDetailForSiteDto
        {
            Brand = product.Brand.Name,
            Category = $"{product.Category.ParentName}  - {product.Category.Name}",
            Description = product.Description,
            Id = product.Id,
            Price = product.Price,
            Title = product.Name,
            Images = product.Images.Select(p => p.Src).ToList(),
            Features = product.Features.Select(p => new ProductDetailForSiteFeaturesDto
            {
                DisplayName = p.KeyName,
                Value = p.KeyValue
            }).ToList()
        };
    }

    private IQueryable<Product> GenerateQueryForProduct(long id)
    {
        return Context.Products
            .Include(p => p.Category)
            .Include(x => x.Brand)
            .Include(p => p.Images)
            .Include(p => p.Features)
            .Where(p => p.Id == id);
    }
}