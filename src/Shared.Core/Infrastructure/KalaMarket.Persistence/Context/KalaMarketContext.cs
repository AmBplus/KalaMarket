﻿using System.Reflection;
using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Domain.Identity.UserAgg;
using KalaMarket.Domain.ShopManagement.ProductAgg;
using KalaMarket.Persistence.HomePage.Configuration;
using KalaMarket.Persistence.Identity.Configuration;
using KalaMarket.Persistence.ShopManagement.Configuration;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Persistence.Context;

public class KalaMarketContext : DbContext, IKalaMarketContext
{
    #region Ctor

    public KalaMarketContext(DbContextOptions<KalaMarketContext> options) : base(options)
    {
    }

    #endregion Ctor

    #region Method

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BrandConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    #endregion Method

    #region Properties

    public DbSet<User> Users { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ProductFeatures> ProductFeatures { get; set; }
    public DbSet<ProductImages> ProductImages { get; set; }
    public DbSet<Slider> Sliders { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<CartItem> CartItems { get; set; }

    #endregion Properties
}