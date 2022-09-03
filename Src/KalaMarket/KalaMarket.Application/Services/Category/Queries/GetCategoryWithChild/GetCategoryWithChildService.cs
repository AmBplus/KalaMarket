using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.Services.Category.Queries.GetCategoryWithChild;

public class GetCategoryWithChildService : IGetCategoryWithChildService
{
    public GetCategoryWithChildService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
}