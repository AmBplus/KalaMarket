﻿using KalaMarket.Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Map;

public class MapUserInRole : IEntityTypeConfiguration<UserInRole>
{
    public void Configure(EntityTypeBuilder<UserInRole> builder)
    {
        builder.HasOne(x => x.Role).WithMany(x => x.UserInRoles).HasForeignKey(x => x.RoleId);
        builder.HasOne(x => x.User).WithMany(x => x.UserInRoles).HasForeignKey(x => x.UserId);
    }
}