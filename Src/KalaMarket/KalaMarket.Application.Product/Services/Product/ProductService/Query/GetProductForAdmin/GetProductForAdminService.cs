using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductForAdmin;

public class GetProductForAdminService : IGetProductForAdminService
{
    public GetProductForAdminService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ResultDto<GetProductForAdminDto> Execute(RequestGetProductForAdmin requestGetProductsForAdmin)
    {
        var products = Context.Products
            .Where(x => x.IsRemoved == requestGetProductsForAdmin.GetIsRemoved)
            .Include(x => x.Category).Include(x => x.Brand)
            .Select(x =>
            new GetProductForAdminDto()
            {
                Name = x.Name,
                Brand = x.Brand.Name,
                Category = x.Category.Name,
                Description = x.Description,
                Displayed = x.Displayed,
                Id = x.Id,
                Inventory = x.Inventory,
                Price = x.Price,
            }).FirstOrDefault(x => x.Id == requestGetProductsForAdmin.Id);

        ResultDto<GetProductForAdminDto> result;
        if (products == null)
        {
            result = new ResultDto<GetProductForAdminDto>(new GetProductForAdminDto());
            result.Message = ErrorMessages.NotFind;
        }
        else
        {
            result = new ResultDto<GetProductForAdminDto>(products);
            result.Message = Messages.OperationDoneSuccessfully;
            result.IsSuccess = true;
        }
        return result;
    }
}