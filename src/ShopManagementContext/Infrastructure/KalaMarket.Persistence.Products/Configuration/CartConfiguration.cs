using KalaMarket.Domain.Products.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Products.Configuration;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasMany(x => x.CartItems)
            .WithOne(x => x.Cart).HasForeignKey(x => x.CartId);
    }
}