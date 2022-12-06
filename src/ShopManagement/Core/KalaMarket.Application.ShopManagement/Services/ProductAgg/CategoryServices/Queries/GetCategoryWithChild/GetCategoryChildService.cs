using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategory;
using KalaMarket.Resourses;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithChild;

public class GetCategoryChildService : IGetCategoryChildService
{
    public GetCategoryChildService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }

    public ResultDto<GetCategoryChildServiceDto> Execute(long id)
    {
        var result =
            new ResultDto<GetCategoryChildServiceDto>(null);
        if (id < 1)
        {
            result.Message = string.Format(ErrorMessages.NotFind, PropertiesName.Category);
            return result;
        }

        result.Data = Context.Categories.Where(x => x.Id == id).Include(x => x.SubCategories)
            .Select(x => new GetCategoryChildServiceDto
            {
                Name = x.Name,
                Id = x.Id,
                CategoryType = x.CategoryType,
                ChildCategories = x.SubCategories.Select(c => new GetCategoryServiceDto
                {
                    Name = c.Name,
                    Id = c.Id
                })
            }).FirstOrDefault()!;
        result.Message = Messages.OperationDoneSuccessfully;
        result.IsSuccess = true;
        return result;
    }
}