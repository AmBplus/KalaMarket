using KalaMarket.Application.Interfaces.Context;

namespace KalaMarket.Application.Product.Services.ProductAgg.CategoryServices.Commands.RemoveCategory;

public class RemoveCategoryService : IRemoveCategoryService
{
    public RemoveCategoryService(IKalaMarketContext context)
    {
        Context = context;
    }

    private IKalaMarketContext Context { get; }
}