using KalaMarket.Application.Product.Services.Products.BrandService.Query.Get;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Query.GetAll;

public class GetAllBrandServiceDto
{
    public List<GetBrandServiceDto> Brands { get; set; }
}