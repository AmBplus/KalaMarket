using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategory;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategories;

public class GetCategoriesService  : IGetCategoriesService
{
    public GetCategoriesService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
    public ResultDto<GetCategoriesServiceDto> Execute(byte? type = null)
    {
        var list = Context.Categories.Where(x => type != null ? (x.CategoryType == type) : (true))
            .Include(x => x.SubCategories)
            .Select(x => new GetCategoryServiceDto()
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.CategoryType,
                HasChild = x.SubCategories.Count > 0
            }).ToList();
        ResultDto<GetCategoriesServiceDto> result = new ResultDto<GetCategoriesServiceDto>(new GetCategoriesServiceDto());
        result.Data._categories = list;
        if (list != null)
        {
            result.IsSuccess = true;
            result.Message = Messages.OperationDoneSuccessfully;
        }
        else
        {
            result.Message = string.Format(ErrorMessages.NotFind,PropertiesName.Categories);
        }
        return result;
    }
}