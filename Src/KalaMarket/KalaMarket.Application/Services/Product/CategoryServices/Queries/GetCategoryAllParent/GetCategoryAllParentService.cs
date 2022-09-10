using System.Text;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Shared.Dto;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryAllParent;

public class GetCategoryAllParentService : IGetCategoryAllParentService
{
    public GetCategoryAllParentService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
    private long ultimateParentCategoryId { get; set; }
    
    public ResultDto<GetCategoryAllParentServiceDto> Execute(long categoryId)
    {
        var categories = FindUltimateParentCategoryId(categoryId);
        ResultDto<GetCategoryAllParentServiceDto> result = new ResultDto<GetCategoryAllParentServiceDto>(categories);
        return  result;

    }

    private GetCategoryAllParentServiceDto FindUltimateParentCategoryId(long? categoryId)
    {
        var categoryParent = Context.Categories.Where(x => x.Id == categoryId)?.Select(x=> new GetCategoryAllParentServiceDto()
        {
                Id = x.Id,
                Name = x.Name,
                ParentId = x.ParentCategoryId
        }).FirstOrDefault();
        if (categoryParent != null && categoryParent.ParentId != null && categoryParent.ParentId!= 0)
        {
           categoryParent.Parent = FindUltimateParentCategoryId(categoryParent.ParentId);
        }
        else
        {
            ultimateParentCategoryId = (long)categoryId;
        }
        return categoryParent;

    }
}