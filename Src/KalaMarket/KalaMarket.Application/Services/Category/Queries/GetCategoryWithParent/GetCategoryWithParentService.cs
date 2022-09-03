using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.Services.Category.Queries.GetCategoryWithParent;

public class GetCategoryWithParentService : IGetCategoryWithParentService
{
    public GetCategoryWithParentService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
}