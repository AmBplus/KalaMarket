using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductForAdmin;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductsForAdmin;

public class GetProductsForAdminService : IGetProductsForAdminService
{
    public GetProductsForAdminService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
    }

    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public ResultDto<GetProductsForAdminDto> Execute(RequestGetProductsForAdmin requestGetProductsForAdmin)
    {
        var rowCount = 0;
        var products = Context.Products
            .Where(x => x.IsRemoved == requestGetProductsForAdmin.GetIsRemoved)
            .Include(x => x.Category).Include(x => x.Brand).ProjectToType<GetProductForAdminDto>()
            .ToPaged(requestGetProductsForAdmin.Page, requestGetProductsForAdmin.PageSize, out rowCount)
            .ToList();
        ResultDto<GetProductsForAdminDto> result;

        if (products == null)
        {
            result = new ResultDto<GetProductsForAdminDto>(new GetProductsForAdminDto
            {
                Products = new List<GetProductForAdminDto>()
            });
            result.Message = ErrorMessages.NotFind;
        }
        else
        {
            result = new ResultDto<GetProductsForAdminDto>(new GetProductsForAdminDto
            {
                Products = products,
                CurrentPage = requestGetProductsForAdmin.Page,
                PageSize = requestGetProductsForAdmin.PageSize,
                RowCount = rowCount
            });
            result.IsSuccess = true;
            result.Message = Messages.OperationDoneSuccessfully;
        }

        return result;
    }
}