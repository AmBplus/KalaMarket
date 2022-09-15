using System.Reflection;
using KalaMarket.Domain.Entities.ProductAgg.CategoryAgg;
using KalaMarket.Domain.Entities.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Interfaces.Context;

public interface IKalaMarketContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<UserInRole> UserInRoles { get; set; }
    DbSet<Category> Categories { get; set; }
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}