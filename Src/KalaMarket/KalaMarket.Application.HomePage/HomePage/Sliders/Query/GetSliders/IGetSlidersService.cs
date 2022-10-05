using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;

public interface IGetSlidersService
{
    ResultDto<ResultGetSlidersDto> Execute(RequestGetSlidersDto request);
    Task<ResultDto<ResultGetSlidersDto>> ExecuteAsync(RequestGetSlidersDto request);
}