using KalaMarket.Domain.HomePage.HomePages;
using KalaMarket.Domain.Products.ProductAgg;
using KalaMarket.Domain.Users.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace KalaMarket.Application.Interfaces.Context;

public interface IKalaMarketContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<UserInRole> UserInRoles { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Brand> Brands { get; set; }
    DbSet<ProductFeatures> ProductFeatures { get; set; }
    DbSet<ProductImages> ProductImages { get; set; }
    DbSet<Slider> Sliders { get; set; }
    DbSet<Cart> Carts { get; set; }
    DbSet<CartItem> CartItems { get; set; }
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}