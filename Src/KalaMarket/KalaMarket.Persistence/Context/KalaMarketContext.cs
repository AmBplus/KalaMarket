﻿using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore;
namespace KalaMarket.Persistence.Context;
public class KalaMarketContext : DbContext , IKalaMarketContext
{
    #region Ctor
    public KalaMarketContext(DbContextOptions<KalaMarketContext> options) : base(options)
    {
    }
    #endregion Ctor

    #region Properties

    public DbSet<User> Users { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
    public DbSet<Role> Roles { get; set; }

    #endregion Properties

    #region Method

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(KalaMarketContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }

    #endregion Method
}