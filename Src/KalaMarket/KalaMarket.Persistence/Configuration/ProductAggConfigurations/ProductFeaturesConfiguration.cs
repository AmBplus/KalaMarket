using KalaMarket.Domain.Entities.ProductAgg;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Configuration.ProductAggConfigurations;

public class ProductFeaturesConfiguration : IEntityTypeConfiguration<ProductFeatures>
{
    public void Configure(EntityTypeBuilder<ProductFeatures> builder)
    {
        builder.Property(x => x.KeyName)
            .HasMaxLength(KalaMarketConstants.MaxLength.Name);
        builder.Property(x => x.Value)
            .HasMaxLength(KalaMarketConstants.MaxLength.Name);
        builder
            .HasOne(x => x.Product)
            .WithMany(x => x.Features)
            .HasForeignKey(x => x.ProductId);

    }
}