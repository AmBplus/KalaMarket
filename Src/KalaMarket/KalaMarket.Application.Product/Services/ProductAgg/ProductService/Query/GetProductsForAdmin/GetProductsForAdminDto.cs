﻿using KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductForAdmin;

namespace KalaMarket.Application.Product.Services.ProductAgg.ProductService.Query.GetProductsForAdmin;

public class GetProductsForAdminDto
{
    public IEnumerable<GetProductForAdminDto> Products { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }
    public int CurrentPage { get; set; }
}