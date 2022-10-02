using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.Resourses;
using KalaMarket.Shared;
using KalaMarket.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Product.Services.Products.Common.Query.GetMenuItemService;

public class GetMenuItemService : IGetMenuItemService
{
    public GetMenuItemService(IKalaMarketContext context, ILoggerManger logger)
    {
        Context = context;
        Logger = logger;
        result = new ResultDto<IEnumerable<GetMenuItemDto>>(new List<GetMenuItemDto>());
    }

    private ResultDto<IEnumerable<GetMenuItemDto>> result { get; }
    private IKalaMarketContext Context { get; }
    private ILoggerManger Logger { get; }
    public ResultDto<IEnumerable<GetMenuItemDto>> Execute(RequestGetMenuItem request)
    {

        var categories = GenerateQueryForCategory().ToList();
        var message = string.Format(ErrorMessages.NotFind, nameof(categories));
        if (result.CheckNullObject(categories, message))
        {
            Logger.LogError(message);
            return result;
        }
        GenerateResult(categories);

        return result;
    }

    public async Task<ResultDto<IEnumerable<GetMenuItemDto>>> ExecuteAsync(RequestGetMenuItem request)
    {
        var categories = await GenerateQueryForCategory().ToListAsync();
        var message = string.Format(ErrorMessages.NotFind, nameof(categories));
        if (result.CheckNullObject(categories, message))
        {
            Logger.LogError(message);
            return result;
        }
        GenerateResult(categories);

        return result;
    }

    private IQueryable<Category> GenerateQueryForCategory()
    {
        return Context.Categories
            .Include(x => x.SubCategories)
            .Where(x => !x.IsRemoved)
            .Where(x => x.ParentCategoryId == null)
            .AsNoTracking();
    }
    private IEnumerable<GetMenuItemDto> GetMenuItem(List<Category> categories)
    {
        return categories.Select(c => new GetMenuItemDto()
        {
            Name = c.Name,
            CategoryId = c.Id,
            Child = c.SubCategories?.Select(sc => new GetMenuItemDto()
            {
                Name = sc.Name,
                CategoryId = sc.Id,
                Child = new List<GetMenuItemDto>()
            }).ToList()
        });
    }

    private void GenerateResult(List<Category> categories)
    {
        result.Data = GetMenuItem(categories);
        result.IsSuccess = true;
        result.Message = Messages.OperationDoneSuccessfully;
    }
}