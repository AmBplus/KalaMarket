using KalaMarket.Application.ShopManagement.Services.ProductAgg.ProductService.Query.GetProductForAdmin;
using KalaMarket.Domain.ShopManagement.ProductAgg;
using Mapster;

namespace KalaMarket.Application.ShopManagement.MapConfig.Mapster;

public class MapGetProductForAdminDto : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        config.ForType<Product, GetProductForAdminDto>()
            .Map(des => des.Category, src => src.Category.Name)
            .Map(des => des.Brand, src => src.Brand.Name);
    }
}