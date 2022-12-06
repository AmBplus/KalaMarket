using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetDetailProductForAdmin;

public class GetProductDetailForAdminService : IGetDetailProductForAdminService
{
    public GetProductDetailForAdminService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public ResultDto<ProductDetailForAdmindto> Execute(RequestGetDetailForAdmin request)
    {
        var result = new ResultDto<ProductDetailForAdmindto>(new ProductDetailForAdmindto());
        var product = Context.Products
            .Include(p => p.Category)
            .Include(x => x.Brand)
            .Include(p => p.Features)
            .Include(p => p.Images)
            .Where(p => p.Id == request.Id)
            .FirstOrDefault();
        if (product == null)
        {
            result.Message = ErrorMessages.NotFind;
            Logger.LogInformation(result.Message);
            return result;
        }

        result.Data = new ProductDetailForAdmindto
        {
            Brand = product.Brand.Name,
            Category = product.Category.ParentName + "---" + product.Category.Name,
            Description = product.Description,
            Displayed = product.Displayed,
            Id = product.Id,
            Inventory = product.Inventory,
            Name = product.Name,
            Price = product.Price,
            Features = product.Features.ToList().Select(p => new ProductDetailFeatureDto
            {
                Id = p.Id,
                DisplayName = p.KeyName,
                Value = p.KeyValue
            }).ToList(),
            Images = product.Images.ToList().Select(p => new ProductDetailImagesDto
            {
                Id = p.Id,
                Src = p.Src
            }).ToList()
        };
        result.IsSuccess = true;
        result.Message = Messages.OperationDoneSuccessfully;
        return result;
    }
}