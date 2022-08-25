using KalaMarket.Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Map;

public class MapRole : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasMany(x => x.UserInRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId);
        builder.Property(x => x.Name).HasMaxLength(100);
    }
}