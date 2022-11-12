using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Queries.GetCategoryWithParentChild;

public class GetCategoryWithParentChildService : IGetCategoryWithParentChildService
{
    public GetCategoryWithParentChildService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
}