﻿namespace KalaMarket.Application.Product.Services.Products.BrandService.Facade.Interface;

public interface IBrandFacade
{
    IBrandQueryFacade BrandQuery { get; }
    IBrandCmdFacade brandCmd { get; }
}