using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Product.Services.ProductAgg.Common.Query.GetCategorySite;

public class GetCategorySiteService : IGetCategorySiteService
{
    public GetCategorySiteService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        Result = new ResultDto<IEnumerable<GetCategorySiteServiceDto>>(new List<GetCategorySiteServiceDto>());
    }

    private ResultDto<IEnumerable<GetCategorySiteServiceDto>> Result { get; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public ResultDto<IEnumerable<GetCategorySiteServiceDto>> Execute(RequestGetCategorySiteDto request)
    {
        SetSuccessResult(GenerateQuery().ToList());
        return Result;
    }

    public async Task<ResultDto<IEnumerable<GetCategorySiteServiceDto>>> ExecuteAsync(RequestGetCategorySiteDto request)
    {
        SetSuccessResult(await GenerateQuery().ToListAsync());
        return Result;
    }

    private IQueryable<GetCategorySiteServiceDto> GenerateQuery()
    {
        return Context.Categories.Where(x => x.ParentCategoryId == null).Where(x => x.IsRemoved == false)
            .Select(x => new GetCategorySiteServiceDto
            {
                Name = x.Name,
                Id = x.Id
            }).AsNoTracking();
    }

    private void SetSuccessResult(List<GetCategorySiteServiceDto> catList)
    {
        Result.Message = Messages.OperationDoneSuccessfully;
        Result.IsSuccess = true;
        Result.Data = catList;
    }
}