using AuthenticationApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}