namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.BrandService.Query.GetAll;

public class RequestGetAllBrandDto
{
    public bool GetActiveBrand { get; set; } = false;
    public bool GetRemovedBrand { get; set; } = false;
}