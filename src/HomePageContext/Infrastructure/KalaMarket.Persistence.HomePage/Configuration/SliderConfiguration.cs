using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.HomePage.Configuration;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(x => x.Src).HasMaxLength(KalaMarketConstants.MaxLength.Name * 2);
        builder.Property(x => x.Link).HasMaxLength(KalaMarketConstants.MaxLength.Name * 2);
    }
}