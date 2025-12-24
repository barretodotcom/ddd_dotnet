using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StockService.Infrastructure.Persistence.AppDbContexts;

namespace StockService.Infrastructure.Persistence.Factories;

    public class AppDbContextFactory 
        : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=painel.dev.zentrix.pro;Port=54321;Database=ddd_dotnet;Username=postgres;Password=ddd_dotnet_password;SSL Mode=Disable;Trust Server Certificate=true");

            return new AppDbContext(optionsBuilder.Options);
        }
    }

