using KalaMarket.Domain.Products.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Products.Configuration;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasOne(x => x.Cart)
            .WithMany(x => x.CartItems).HasForeignKey(x => x.CartId);
        builder.HasOne(x => x.Product);
    }
}