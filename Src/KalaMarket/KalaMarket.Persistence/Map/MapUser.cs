using KalaMarket.Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Map;

public class MapUser : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(x => x.UserInRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.Property(x => x.FullName).HasMaxLength(100);
    }
}