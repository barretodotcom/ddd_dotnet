using StockService.Domain.Common.DomainEvents;

namespace StockService.Domain.Common.Abstractions;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
    void AddDomainEvent(IDomainEvent domainEvent);
}