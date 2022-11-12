using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Products.Configuration;

public class ProductFeaturesConfiguration : IEntityTypeConfiguration<ProductFeatures>
{
    public void Configure(EntityTypeBuilder<ProductFeatures> builder)
    {
        builder.Property(x => x.KeyName)
            .HasMaxLength(KalaMarketConstants.MaxLength.Name);
        builder.Property(x => x.KeyValue)
            .HasMaxLength(KalaMarketConstants.MaxLength.Name);
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.Features)
            .HasForeignKey(x => x.ProductId);
    }
}