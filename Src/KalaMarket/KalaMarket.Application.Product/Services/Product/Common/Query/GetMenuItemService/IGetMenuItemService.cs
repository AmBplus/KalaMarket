using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.Common.Query.GetMenuItemService;

public interface IGetMenuItemService
{
    ResultDto<IEnumerable<GetMenuItemDto>> Execute(RequestGetMenuItem request);
    Task<ResultDto<IEnumerable<GetMenuItemDto>>> ExecuteAsync(RequestGetMenuItem request);
}