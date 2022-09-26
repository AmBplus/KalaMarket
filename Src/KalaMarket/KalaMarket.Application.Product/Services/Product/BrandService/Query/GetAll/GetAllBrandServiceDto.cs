using KalaMarket.Application.Product.Services.Product.BrandService.Query.Get;

namespace KalaMarket.Application.Product.Services.Product.BrandService.Query.GetAll;

public class GetAllBrandServiceDto 
{
    public List<GetBrandServiceDto> Brands { get; set; }
}