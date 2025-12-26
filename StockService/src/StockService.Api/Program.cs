using NNotificator.Abstractions;
using NNotificator.DependencyInjection;
using StockService.Application;
using StockService.Application.DependencyInjection;
using StockService.Application.Products.Handlers;
using StockService.Infrastructure;
using StockService.Infrastructure.DependencyInjection;
using StockService.Infrastructure.Persistence.AppDbContexts;
using StockService.Infrastructure.Persistence.Configuration;
using StockService.Infrastructure.Persistence.Interceptor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application & Infrastructure
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddNotificator(
    typeof(ProductCreatedHandler).Assembly
    );

builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    var eventPublisher = sp.GetRequiredService<IEventPublisher>();
    options.AddInterceptors(new DomainEventInterceptor(eventPublisher));
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();