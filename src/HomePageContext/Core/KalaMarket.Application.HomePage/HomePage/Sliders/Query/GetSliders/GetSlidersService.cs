using KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSlider;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;

public class GetSlidersService : IGetSlidersService
{
    #region Properties

    public GetSlidersService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        Result = new ResultDto<ResultGetSlidersDto>(new ResultGetSlidersDto());
    }

    private ResultDto<ResultGetSlidersDto> Result { get; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    #endregion /Properties

    #region Public Methods

    public ResultDto<ResultGetSlidersDto> Execute(RequestGetSlidersDto request)
    {
        var sliders = GenerateQuery(request).ToList();
        if (Result.CheckIsNullObject(sliders, string.Format(ErrorMessages.NotFind, nameof(sliders)))) return Result;
        return SetResult(sliders);
    }

    public async Task<ResultDto<ResultGetSlidersDto>> ExecuteAsync(RequestGetSlidersDto request)
    {
        var sliders = await GenerateQuery(request).ToListAsync();
        if (Result.CheckIsNullObject(sliders, string.Format(ErrorMessages.NotFind, nameof(sliders)))) return Result;
        return SetResult(sliders);
    }

    #endregion /Public Methods

    #region Private Methods

    private ResultDto<ResultGetSlidersDto> SetResult(IEnumerable<ResultGetSliderDto> sliders)
    {
        Result.Data.Sliders = sliders;
        Result.IsSuccess = true;
        Result.Message = Messages.OperationDoneSuccessfully;
        return Result;
    }

    private IQueryable<ResultGetSliderDto> GenerateQuery(RequestGetSlidersDto request)
    {
        int recordCount;
        var query = Context.Sliders.Select(x => new ResultGetSliderDto
        {
            Link = x.Link,
            Id = x.Id,
            Src = x.Src
        }).ToPaged(request.Page, request.PageSize, out recordCount);
        Result.Data.Page = request.Page;
        Result.Data.PageSize = request.PageSize;
        Result.Data.RecordCount = recordCount;
        return query;
    }

    #endregion /Private Methods
}