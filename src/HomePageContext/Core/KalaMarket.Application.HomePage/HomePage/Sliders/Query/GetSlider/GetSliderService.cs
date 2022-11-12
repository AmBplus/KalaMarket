using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSlider;

public class GetSliderService : IGetSliderService
{
    #region Constructor

    public GetSliderService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        Result = new ResultDto<ResultGetSliderDto>(new ResultGetSliderDto());
    }

    #endregion

    #region Properties

    private ResultDto<ResultGetSliderDto> Result { get; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    #endregion /Properties

    #region Puplic Methods

    public ResultDto<ResultGetSliderDto> Execute(RequestGetSliderDto request)
    {
        var slider = GenerateQuery(request).FirstOrDefault();
        if (Result.CheckIsNullObject(slider, string.Format(ErrorMessages.NotFind, nameof(slider)))) return Result;
        return SetResult(slider!);
    }

    public async Task<ResultDto<ResultGetSliderDto>> ExecuteAsync(RequestGetSliderDto request)
    {
        ResultGetSliderDto slider = await GenerateQuery(request).FirstOrDefaultAsync();
        if (Result.CheckIsNullObject(slider, string.Format(ErrorMessages.NotFind, nameof(slider)))) return Result;
        return SetResult(slider!);
    }

    #endregion

    #region Private Methods

    private ResultDto<ResultGetSliderDto> SetResult(ResultGetSliderDto slider)
    {
        Result.Data = slider;
        Result.IsSuccess = true;
        Result.Message = Messages.OperationDoneSuccessfully;
        return Result;
    }

    private IQueryable<ResultGetSliderDto> GenerateQuery(RequestGetSliderDto request)
    {
        return Context.Sliders.Where(x => x.Id == request.Id).Select(x => new ResultGetSliderDto
        {
            Link = x.Link,
            Id = x.Id,
            Src = x.Src
        });
    }

    #endregion /Private Methods
}