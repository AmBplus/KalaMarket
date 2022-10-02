using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Products.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.ParentName).IsRequired(false);
        builder.Property(x => x.ParentCategoryId).IsRequired(false);
        builder.Property(x => x.RemoveTime).IsRequired(false);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(KalaMarketConstants.MaxLength.Name);
        builder.Property(x => x.Id);
        builder.Property(x => x.IsRemoved);
        builder.Property(x => x.UpdateTime);
        builder.Property(x => x.InsertTime);
        builder.Property(x => x.CategoryType);
        builder.HasOne(x => x.ParentCategory)
            .WithMany(x => x.SubCategories).HasForeignKey
            (x => x.ParentCategoryId);
        builder
            .HasMany(x => x.SubCategories)
            .WithOne(x => x.ParentCategory)
            .HasForeignKey(x => x.ParentCategoryId);
    }
}