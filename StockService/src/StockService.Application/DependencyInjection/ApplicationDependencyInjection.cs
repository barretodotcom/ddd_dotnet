using Microsoft.Extensions.DependencyInjection;
using StockService.Application.Locals.Services.CreateLocalServices;
using StockService.Application.Locals.Services.GetLocalService;

namespace StockService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateLocalService, CreateLocalService>();
        services.AddScoped<IGetLocalService, GetLocalService>();
        
        return services;
    }
}