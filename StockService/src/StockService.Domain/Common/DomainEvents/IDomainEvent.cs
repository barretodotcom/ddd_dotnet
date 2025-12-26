using NNotificator.Abstractions;

namespace StockService.Domain.Common.DomainEvents;

public interface IDomainEvent : IEvent
{
    public Guid EventId { get; }
}