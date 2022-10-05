namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Query.GetAll;

public class RequestGetAllBrandDto
{
    public bool GetActiveBrand { get; set; } = false;
    public bool GetRemovedBrand { get; set; } = false;
}