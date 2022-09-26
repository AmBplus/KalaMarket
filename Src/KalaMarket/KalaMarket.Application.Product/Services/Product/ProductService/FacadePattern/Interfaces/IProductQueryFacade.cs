using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductForAdmin;
using KalaMarket.Application.Product.Services.Product.ProductService.Query.GetProductsForAdmin;

namespace KalaMarket.Application.Product.Services.Product.ProductService.FacadePattern.Interfaces;

public interface IProductQueryFacade
{
    /// <summary>
    ///  دریافت تک محصول
    /// </summary>
    IGetProductForAdminService ProductForAdmin { get;  }
    /// <summary>
    /// دریافت محصولات 
    /// </summary>
    IGetProductsForAdminService ProductsForAdmin { get; }
}