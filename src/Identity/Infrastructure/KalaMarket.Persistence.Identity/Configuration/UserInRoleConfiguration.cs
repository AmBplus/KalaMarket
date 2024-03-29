﻿using KalaMarket.Domain.Identity.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KalaMarket.Persistence.Identity.Configuration;

public class UserInRoleConfiguration : IEntityTypeConfiguration<UserInRole>
{
    public void Configure(EntityTypeBuilder<UserInRole> builder)
    {
        builder.HasOne(x => x.Role).WithMany(x => x.UserInRoles).HasForeignKey(x => x.RoleId);
        builder.HasOne(x => x.User).WithMany(x => x.UserInRoles).HasForeignKey(x => x.UserId);
    }
}