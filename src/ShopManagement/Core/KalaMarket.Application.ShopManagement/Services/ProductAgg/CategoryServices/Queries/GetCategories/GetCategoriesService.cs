using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategory;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.ShopManagement.Services.ProductAgg.CategoryServices.Queries.GetCategories;

public class GetCategoriesService : IGetCategoriesService
{
    public GetCategoriesService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }

    public ResultDto<GetCategoriesServiceDto> Execute(RequestGetCategoriesDto request)
    {
        var rowCount = 0;

        var query = Context.Categories.Where(x => request.Type != null ? x.CategoryType == request.Type : true)
            .Include(x => x.SubCategories)
            .Select(x => new GetCategoryServiceDto
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.CategoryType,
                HasChild = x.SubCategories.Count > 0,
                ParentName = x.ParentName
            });
        List<GetCategoryServiceDto> list;
        if (request.Page > 0 && request.PageSize > 0)
            list = query.ToPaged(request.Page, request.PageSize, out rowCount).ToList();
        else
            list = query.ToList();
        var result =
            new ResultDto<GetCategoriesServiceDto>(new GetCategoriesServiceDto());
        result.Data._categories = list;
        if (list != null)
        {
            result.IsSuccess = true;
            result.Data.RowCount = rowCount;
            result.Data.PageSize = request.PageSize;
            result.Data.CurrentPage = request.Page;
            result.Message = Messages.OperationDoneSuccessfully;
        }
        else
        {
            result.Message = string.Format(ErrorMessages.NotFind, PropertiesName.Categories);
        }

        return result;
    }
}