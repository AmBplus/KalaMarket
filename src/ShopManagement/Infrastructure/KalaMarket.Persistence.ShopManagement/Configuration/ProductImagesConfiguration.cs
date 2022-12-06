using KalaMarket.Domain.ShopManagement.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.ShopManagement.Configuration;

public class ProductImagesConfiguration : IEntityTypeConfiguration<ProductImages>
{
    public void Configure(EntityTypeBuilder<ProductImages> builder)
    {
        builder.HasIndex(x => x.ProductId);
        builder.HasOne(x => x.Product)
            .WithMany(x => x.Images)
            .HasForeignKey(x => x.ProductId);
    }
}