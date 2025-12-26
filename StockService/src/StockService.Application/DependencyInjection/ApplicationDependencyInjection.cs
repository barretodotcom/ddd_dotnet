using Microsoft.Extensions.DependencyInjection;
using StockService.Application.Common.Result;
using StockService.Application.Locals.Services.CreateLocalServices;
using StockService.Application.Locals.Services.GetLocalService;
using StockService.Application.Products.Service.CreateProductService;
using StockService.Application.Products.Service.CreateProductService.Validator;

namespace StockService.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region Locals
        services.AddScoped<ICreateLocalService, CreateLocalService>();
        services.AddScoped<IGetLocalService, GetLocalService>();
        #endregion

        #region Product
        services.AddScoped<ICreateProductService, CreateProductService>();
        services.AddScoped<ICreateProductValidatorService, CreateProductValidatorService>();
        #endregion
        
        #region Result
        services.AddScoped<IResultService, ResultService>();
        #endregion
        
        return services;
    }
}