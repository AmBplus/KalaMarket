﻿using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetMenuItemService;

public interface IGetMenuItemService
{
    ResultDto<IEnumerable<GetMenuItemDto>> Execute(RequestGetMenuItem request);
    Task<ResultDto<IEnumerable<GetMenuItemDto>>> ExecuteAsync(RequestGetMenuItem request);
}