﻿using KalaMarket.Application.Product.Services.Products.ProductService.Query.GetDetailProductForAdmin;
using KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductDetailForSite;
using KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductForAdmin;
using KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductsForAdmin;
using KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductsForSite;

namespace KalaMarket.Application.Product.Services.Products.ProductService.FacadePattern.Interfaces;

public interface IProductQueryFacade
{
    /// <summary>
    ///  دریافت تک محصول
    /// </summary>
    IGetProductForAdminService ProductForAdmin { get; }
    /// <summary>
    /// دریافت محصولات 
    /// </summary>
    IGetProductsForAdminService ProductsForAdmin { get; }
    /// <summary>
    /// دریافت جزییات محصول برای ادمین
    /// </summary>
    IGetDetailProductForAdminService DetailProductForAdmin { get; }
    /// <summary>
    /// دریافت محصولات برای نمایش در سایت
    /// </summary>
    IGetProductsForSiteService ProductsForSite { get; }
    /// <summary>
    /// دیدن جزییات محصول برای نمایش در سایت
    /// </summary>
    IGetProductDetailForSiteService ProductDetailForSite { get; }
}