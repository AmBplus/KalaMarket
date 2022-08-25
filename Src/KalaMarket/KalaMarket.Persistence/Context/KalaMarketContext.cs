using KalaMarket.Application.Interfaces.Context;
using KalaMarket.Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace KalaMarket.Persistence.Context;

public class KalaMarketContext : DbContext , IKalaMarketContext
{
    public KalaMarketContext(DbContextOptions<KalaMarketContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
    public DbSet<Role> Roles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(KalaMarketContext).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }
}