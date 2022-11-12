using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersForSite;

public class GetSliderForSiteService : IGetSliderForSiteService
{
    #region Properties

    public GetSliderForSiteService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        Result = new ResultDto<ResultGetSlidersForSiteDto>(new ResultGetSlidersForSiteDto
            { Sliders = new List<GetSlidersForSiteDto>() });
    }

    private ResultDto<ResultGetSlidersForSiteDto> Result { get; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    #endregion /Properties

    #region Public Methods

    public ResultDto<ResultGetSlidersForSiteDto> Execute(RequestGetSildersForSiteDto request)
    {
        var sliders = GenerateQuery(request).ToList();
        if (Result.CheckIsNullObject(sliders, string.Format(ErrorMessages.NotFind, nameof(sliders)))) return Result;
        return SetResult(sliders);
    }

    public async Task<ResultDto<ResultGetSlidersForSiteDto>> ExecuteAsync(RequestGetSildersForSiteDto request)
    {
        var sliders = await GenerateQuery(request).ToListAsync();
        if (Result.CheckIsNullObject(sliders, string.Format(ErrorMessages.NotFind, nameof(sliders)))) return Result;
        return SetResult(sliders);
    }

    #endregion /Public Methods

    #region Private Methods

    private ResultDto<ResultGetSlidersForSiteDto> SetResult(IEnumerable<GetSlidersForSiteDto> sliders)
    {
        Result.Data.Sliders = sliders;
        Result.IsSuccess = true;
        Result.Message = Messages.OperationDoneSuccessfully;
        return Result;
    }

    private IQueryable<GetSlidersForSiteDto> GenerateQuery(RequestGetSildersForSiteDto request)
    {
        var query = Context.Sliders.AsQueryable();
        if (request.Filter != null) query = query.Where(request.Filter);

        var result = query.Select(x => new GetSlidersForSiteDto
        {
            Link = x.Link,
            Id = x.Id,
            Src = x.Src
        });

        return result;
    }

    #endregion /Private Methods
}