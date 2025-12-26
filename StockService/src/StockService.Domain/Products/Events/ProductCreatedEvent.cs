using NNotificator.Abstractions;
using StockService.Domain.Common.DomainEvents;
using StockService.Domain.Products.ValueObjects;

namespace StockService.Domain.Products.Events;

public class ProductCreatedEvent : IDomainEvent
{
    public Guid EventId { get; }
    public ProductId ProductId { get; }

    public ProductCreatedEvent(ProductId productId)
    {
        EventId = Guid.NewGuid();
        ProductId = productId;
    }
}