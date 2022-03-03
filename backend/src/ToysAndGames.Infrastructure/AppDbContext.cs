using Microsoft.EntityFrameworkCore;
using ToysAndGames.Data.Models;

namespace ToysAndGames.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(14, 2);
        //modelBuilder.Entity<Product>().HasData()
    }
}