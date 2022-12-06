using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.ShopManagement.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(KalaMarketConstants.MaxLength.Name);
        builder.HasIndex(x => x.Name);
        builder
            .HasMany(x => x.Features)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
        builder
            .HasMany(x => x.Images)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);
        builder
            .HasOne(x => x.Brand)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.BrandId);
    }
}