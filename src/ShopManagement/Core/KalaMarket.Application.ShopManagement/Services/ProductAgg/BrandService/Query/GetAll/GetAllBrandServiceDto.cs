using KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Query.Get;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Query.GetAll;

public class GetAllBrandServiceDto
{
    public List<GetBrandServiceDto> Brands { get; set; }
}