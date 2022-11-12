using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Validations.Brand;
using KalaMarket.Application.Utility;
using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.ProductAgg.BrandService.Command.Add;

public class AddBrandService : IAddBrandService
{
    public AddBrandService(ILoggerManger logger, IKalaMarketContext context)
    {
        Logger = logger;
        Context = context;
    }

    private ILoggerManger Logger { get; }
    private IKalaMarketContext Context { get; }

    public ResultDto<AddBrandServiceDto> Execute(RequestAddBrand requestAddBrand)
    {
        ResultDto<AddBrandServiceDto> result = new ResultDto<AddBrandServiceDto>(null);
        // Validate Request 
        if (ValidationRequestAddBrand(result, requestAddBrand)) return result;
        // Create Instance
        var brand = CreateInstance(requestAddBrand);
        // ADD
        Context.Brands.Add(brand);
        // Save
        if (!Context.HandleSaveChange(result, Logger))
            return result; // If SaveChange Return False
        result.Data = new AddBrandServiceDto();
        result.Data.Id = brand.Id;
        return result;
    }

    private Brand CreateInstance(RequestAddBrand requestAddBrand)
    {
        return new Brand(requestAddBrand.Name);
    }

    private bool ValidationRequestAddBrand(ResultDto<AddBrandServiceDto> result, RequestAddBrand requestAddBrand)
    {
        var validateRequestAddBrand = new ValidateRequestAddBrand();
        var resultValidate = validateRequestAddBrand.Validate(requestAddBrand);
        return resultValidate.ValidateResultHasError<AddBrandServiceDto>(result);
    }
}