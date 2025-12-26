using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockService.Application.Stocks.ReadOnlyRepositories;
using StockService.Domain.Stocks.Repositories;
using StockService.Infrastructure.Persistence.AppDbContexts;
using StockService.Infrastructure.Persistence.Repositories;
using StockService.Domain.Locals.Repositories;
using StockService.Domain.Products.Repositories;
using StockService.Infrastructure.Persistence.Repositories.ReadOnly;

namespace StockService.Infrastructure.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<ILocalRepository, LocalRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IStockReadOnlyRepository, StockReadOnlyRepository>();
        
        return services;
    }
}