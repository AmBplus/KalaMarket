﻿using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.Common.Query.GetCategorySite;

public interface IGetCategorySiteService
{
    ResultDto<IEnumerable<GetCategorySiteServiceDto>> Execute(RequestGetCategorySiteDto request);
    Task<ResultDto<IEnumerable<GetCategorySiteServiceDto>>> ExecuteAsync(RequestGetCategorySiteDto request);
}