using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Category.Queries.GetCategoryAllParent;

public class GetCategoryAllParentService : IGetCategoryAllParentService
{
    private IKalaMarketContext Context { get; }
    private long ultimateParentCategoryId { get; set; }
    public ResultDto<GetCategoryAllParentServiceDto> Execute(long categoryId)
    {
        FindUltimateParentCategoryId(categoryId);
        return null;
    }

    private void FindUltimateParentCategoryId(long? categoryId)
    {
        var categoryParentId = Context.Categories.Where(x => x.Id == categoryId).Select(x => x.ParentCategoryId)
            .FirstOrDefault();
        if (categoryParentId != null && categoryParentId != 0)
        {
            FindUltimateParentCategoryId(categoryParentId);
        }
        else
        {
            ultimateParentCategoryId = (long)categoryId;
        }

  
    }
}