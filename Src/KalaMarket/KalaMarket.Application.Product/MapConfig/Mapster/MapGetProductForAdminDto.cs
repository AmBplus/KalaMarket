using KalaMarket.Application.Product.Services.Products.ProductService.Query.GetProductForAdmin;
using Mapster;

namespace KalaMarket.Application.Product.MapConfig.Mapster;

public class MapGetProductForAdminDto : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
        config.ForType<Domain.Products.ProductAgg.Product, GetProductForAdminDto>()
            .Map(des => des.Category, src => src.Category.Name)
            .Map(des => des.Brand, src => src.Brand.Name);
    }
}