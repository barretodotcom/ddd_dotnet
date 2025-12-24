using StockService.Domain.Stocks.Entities;
using StockService.Domain.Locals.Entities;
using StockService.Domain.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace StockService.Infrastructure.Persistence.AppDbContexts;

public class AppDbContext : DbContext
{
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Local> Locals { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

}