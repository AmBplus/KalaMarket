using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.HomePage.Configuration;

public class SliderConfiguration : IEntityTypeConfiguration<MainSlider>
{
    public void Configure(EntityTypeBuilder<MainSlider> builder)
    {
        builder.Property(x => x.Src).HasMaxLength(KalaMarketConstants.MaxLength.Name * 2);
    }
}