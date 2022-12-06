using KalaMarket.Domain.ShopManagement.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.ShopManagement.Configuration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasMany(x => x.CartItems)
            .WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
    }
}