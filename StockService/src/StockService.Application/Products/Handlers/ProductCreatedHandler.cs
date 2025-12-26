using NNotificator.Abstractions;
using StockService.Application.Products.Commands;
using StockService.Domain.Products.Events;

namespace StockService.Application.Products.Handlers;

public class ProductCreatedHandler : IEventHandler<ProductCreatedEvent>
{
    public Task HandleAsync(ProductCreatedEvent request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"ProductCreatedHandler");
        
        return Task.CompletedTask;
    }
}