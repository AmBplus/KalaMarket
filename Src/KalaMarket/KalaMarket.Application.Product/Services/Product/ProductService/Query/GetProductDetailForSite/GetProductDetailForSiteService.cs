using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductDetailForSite;

public class GetProductDetailForSiteService : IGetProductDetailForSiteService
{
    private IKalaMarketContext Context { get; }
    public ILoggerManger Logger { get; }

    public GetProductDetailForSiteService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }
    public ResultDto<ProductDetailForSiteDto> Execute(RequestGetDetailProductForSiteDto request)
    {
        ResultDto<ProductDetailForSiteDto> result =
            new ResultDto<ProductDetailForSiteDto>(new ProductDetailForSiteDto());
        var Product = GenerateQueryForProduct(request.Id).FirstOrDefault();

        if (CheckIsNullProduct(result, Product!)) return result;

        result.Data = MapToDto(Product!);
        result.IsSuccess = true;
        result.Message = Messages.OperationDoneSuccessfully;
        return result;
    }

    public async Task<ResultDto<ProductDetailForSiteDto>> ExecuteAsync(RequestGetDetailProductForSiteDto request)
    {
        ResultDto<ProductDetailForSiteDto> result =
            new ResultDto<ProductDetailForSiteDto>(new ProductDetailForSiteDto());
        var Product =await GenerateQueryForProduct(request.Id).FirstOrDefaultAsync();

        if (CheckIsNullProduct(result, Product)) return result;
        result.Data = MapToDto(Product);
        result.IsSuccess = true;
        result.Message = Messages.OperationDoneSuccessfully;
        return result;
    }

    private bool CheckIsNullProduct(ResultDto<ProductDetailForSiteDto> result,Domain.Entities.ProductAgg.Product product)
    {
        if (product != null)
        {
            return false;
        }
        var message = string.Format(ErrorMessages.NotFind, nameof(Product));
        Logger.LogError(exception: new NullReferenceException(message), message);
        result.Message = message;
        return true;
    }

    private ProductDetailForSiteDto MapToDto(Domain.Entities.ProductAgg.Product product)
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
                Value = p.KeyValue,
            }).ToList(),
        };
    }

    private IQueryable<Domain.Entities.ProductAgg.Product> GenerateQueryForProduct(long id)
    {
        return Context.Products
            .Include(p => p.Category)
            .Include(x => x.Brand)
            .Include(p => p.Images)
            .Include(p => p.Features)
            .Where(p => p.Id == id);
    }
}
