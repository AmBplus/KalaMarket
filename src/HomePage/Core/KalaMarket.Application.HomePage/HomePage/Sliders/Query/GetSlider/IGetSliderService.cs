using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSlider;

public interface IGetSliderService
{
    ResultDto<ResultGetSliderDto> Execute(RequestGetSliderDto request);
    Task<ResultDto<ResultGetSliderDto>> ExecuteAsync(RequestGetSliderDto request);
}