using KalaMarket.Application.HomePage.HomePage.Sliders.Validation;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Utility;
using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Cmd.AddSlider;

public class AddSliderService : IAddSliderService
{
    public AddSliderService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        Result = new ResultDto();
    }

    private ResultDto Result { get; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }

    public ResultDto Execute(RequestAddSliderServiceDto request)
    {
        if (IsValidRequest(request)) return Result;
        Context.Sliders.Add(new Slider(request.Src, request.Link, request.SliderType));
        Context.HandleSaveChange(Result, Logger);
        if (Result.IsSuccess) Logger.LogInformation("مین اسلایدر جدید ساخته شد");
        return Result;
    }

    private bool IsValidRequest(RequestAddSliderServiceDto request)
    {
        var validationRequestAddSliderServiceDto = new ValidationRequestAddSliderServiceDto();
        var resultValidate = validationRequestAddSliderServiceDto.Validate(request);
        if (resultValidate.ValidateResultHasError(Result)) return true;
        return false;
    }
}