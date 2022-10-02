using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Utility;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Products.BrandService.Command.Active;

public class ChangeBrandActivationService : IChangeBrandActivationService
{
    public ChangeBrandActivationService(ILoggerManger logger, IKalaMarketContext context)
    {
        Logger = logger;
        Context = context;
    }

    private ILoggerManger Logger { get; }
    private IKalaMarketContext Context { get; }
    public ResultDto Execute(RequestChangeActivation requestChangeActivation)
    {
        ResultDto result = new ResultDto();
        var brand = Context.Brands.FirstOrDefault(x => x.Id == requestChangeActivation.Id);
        if (brand == null)
        {
            result.Message = string.Format(ErrorMessages.NotFind, "برند");
            return result;
        }
        if (brand.ChangeActivation() && Context.HandleSaveChange(result, Logger))
        {
            Logger.LogInformation("برند {0} با ایدی {1} تغیر پیدا کرد", brand.Name, brand.Id);
        };
        return result;
    }
}