using System.Xml;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Product.Services.Product.BrandService.Query.Get;
using KalaMarket.Domain.Entities.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Product.Services.Product.BrandService.Query.GetAll;

public class GetAllBrandService : IGetAllBrandService
{
    public GetAllBrandService(IKalaMarketContext context)
    {
        Context = context;
    }

    public GetAllBrandService(IKalaMarketContext context, ILoggerManger logger)
    {
        Logger = logger;
        Context = context;
    }

    private ILoggerManger Logger { get; }
    private IKalaMarketContext Context { get; }
    public ResultDto<GetAllBrandServiceDto> Execute(RequestGetAllBrandDto requestGetAllBrand)
    {
        ResultDto<GetAllBrandServiceDto> AllBrandResult =
            new ResultDto<GetAllBrandServiceDto>(new GetAllBrandServiceDto());
        try
        {
          var query =  Context.Brands
                .Where(x => x.IsRemoved == requestGetAllBrand.GetRemovedBrand);
            if (requestGetAllBrand.GetActiveBrand)
            {
                query = query.Where(x => x.IsActive == true);
            }
            AllBrandResult.Data.Brands = query.Select(x => new GetBrandServiceDto()
                {
                    Name = x.Name,
                    Id = x.Id,
                    IsActive = x.IsActive
                }).ToList();
            AllBrandResult.IsSuccess = true;
            AllBrandResult.Message = Messages.OperationDoneSuccessfully;
        }
        catch (Exception e)
        {
            Logger.LogError(e, e.Message);
            AllBrandResult.Message = ErrorMessages.ProblemOccurred;
        }
        return AllBrandResult;
    }

    
}