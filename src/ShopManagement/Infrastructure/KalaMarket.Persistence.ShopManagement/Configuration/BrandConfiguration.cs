using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.ShopManagement.Configuration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(KalaMarketConstants.MaxLength.Name);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasMany(x => x.Products)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId);
    }
}