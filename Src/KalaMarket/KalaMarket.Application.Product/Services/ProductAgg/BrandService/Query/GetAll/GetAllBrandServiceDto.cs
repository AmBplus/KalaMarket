﻿using KalaMarket.Application.Product.Services.ProductAgg.BrandService.Query.Get;

namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Query.GetAll;

public class GetAllBrandServiceDto
{
    public List<GetBrandServiceDto> Brands { get; set; }
}