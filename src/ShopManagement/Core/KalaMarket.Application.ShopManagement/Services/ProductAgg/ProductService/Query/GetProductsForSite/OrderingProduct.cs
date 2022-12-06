namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductsForSite;

public enum OrderingProduct
{
    /// <summary>
    ///     بدون مرتب سازی
    /// </summary>
    NotOrder,

    /// <summary>
    ///     بیشترین بازدید
    /// </summary>
    MostVisited,

    /// <summary>
    ///     بیشترین فروش
    /// </summary>
    BestSelling,

    /// <summary>
    ///     محبوب ترین
    /// </summary>
    MostPopular,

    /// <summary>
    ///     جدید ترین
    /// </summary>
    TheNewest,

    /// <summary>
    ///     ارزان ترین
    /// </summary>
    Cheapest,

    /// <summary>
    ///     گران ترین
    /// </summary>
    TheMostExpensive
}