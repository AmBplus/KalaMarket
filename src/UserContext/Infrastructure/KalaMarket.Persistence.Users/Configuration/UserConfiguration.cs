using KalaMarket.Domain.Users.UserAgg;
using KalaMarket.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Users.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.UserInRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.Property(x => x.FullName).HasMaxLength(KalaMarketConstants.MaxLength.FullName);
        builder.Property(x => x.Email).IsUnicode(false).HasMaxLength(KalaMarketConstants.MaxLength.EmailAddress);
        builder.HasIndex(x => new { x.Email }).IsUnique();
    }
}