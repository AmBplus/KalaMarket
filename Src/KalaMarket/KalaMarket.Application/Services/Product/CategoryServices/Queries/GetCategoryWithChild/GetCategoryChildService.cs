using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.Services.Product.CategoryServices.Queries.GetCategoryWithChild;

public class GetCategoryChildService : IGetCategoryChildService
{
    public GetCategoryChildService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
}