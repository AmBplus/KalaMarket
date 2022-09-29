using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.Common.Query.GetMenuItemService;

public interface IGetMenuItemService
{
    ResultDto<IEnumerable<GetMenuItemDto>> GetMenuItem(RequestGetMenuItem request);
    Task<ResultDto<IEnumerable<GetMenuItemDto>>> GetMenuItemAsync(RequestGetMenuItem request);
}