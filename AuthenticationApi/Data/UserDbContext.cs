using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}