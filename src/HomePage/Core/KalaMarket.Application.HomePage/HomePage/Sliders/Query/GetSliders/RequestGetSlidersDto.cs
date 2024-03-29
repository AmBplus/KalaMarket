﻿using KalaMarket.Shared;

namespace KalaMarket.Application.HomePage.HomePage.Sliders.Query.GetSliders;

public class RequestGetSlidersDto
{
    public int Page { get; set; } = 1;
    public byte PageSize { get; set; } = KalaMarketConstants.Page.PageSize;
}