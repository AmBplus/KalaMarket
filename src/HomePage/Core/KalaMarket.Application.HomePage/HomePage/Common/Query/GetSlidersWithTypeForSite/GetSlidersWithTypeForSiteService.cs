using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.HomePage.HomePage.Common.Query.GetSlidersWithTypeForSite;

public class GetSlidersWithTypeForSiteService : IGetSlidersWithTypeForSiteService
{
    #region Properties

    public GetSlidersWithTypeForSiteService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        Result = new ResultDto<ResultGetSlidersWithTypeForSiteDto>(new ResultGetSlidersWithTypeForSiteDto
            { Sliders = new List<GetSlidersWithTypeForSiteDto>() });
    }

    private ResultDto<ResultGetSlidersWithTypeForSiteDto> Result { get; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    #endregion /Properties

    #region Public Methods

    public ResultDto<ResultGetSlidersWithTypeForSiteDto> Execute(RequestGetSlidersWithTypeForSiteDto request)
    {
        var sliders = GenerateQuery(request).ToList();
        if (Result.CheckIsNullObject(sliders, string.Format(ErrorMessages.NotFind, nameof(sliders)))) return Result;
        return SetResult(sliders);
    }

    public async Task<ResultDto<ResultGetSlidersWithTypeForSiteDto>> ExecuteAsync(
        RequestGetSlidersWithTypeForSiteDto request)
    {
        var sliders = await GenerateQuery(request).ToListAsync();
        if (Result.CheckIsNullObject(sliders, string.Format(ErrorMessages.NotFind, nameof(sliders)))) return Result;
        return SetResult(sliders);
    }

    #endregion /Public Methods

    #region Private Methods

    private ResultDto<ResultGetSlidersWithTypeForSiteDto> SetResult(IEnumerable<GetSlidersWithTypeForSiteDto> sliders)
    {
        Result.Data.Sliders = sliders;
        Result.IsSuccess = true;
        Result.Message = Messages.OperationDoneSuccessfully;
        return Result;
    }

    private IQueryable<GetSlidersWithTypeForSiteDto> GenerateQuery(RequestGetSlidersWithTypeForSiteDto request)
    {
        var query = Context.Sliders.AsQueryable();
        if (request.Filter != null) query = query.Where(request.Filter);
        return query.Select(x => new GetSlidersWithTypeForSiteDto
        {
            Link = x.Link,
            Id = x.Id,
            Src = x.Src,
            SliderType = x.SliderType
        });
    }

    #endregion /Private Methods
}