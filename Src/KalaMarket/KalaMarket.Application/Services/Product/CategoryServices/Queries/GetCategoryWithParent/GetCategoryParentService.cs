using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithParent;

public class GetCategoryParentService : IGetCategoryParentService
{
    public GetCategoryParentService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
}