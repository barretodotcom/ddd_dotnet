using StockService.Domain.Common.DomainEvents;

namespace StockService.Domain.Common.Abstractions;

public class AggregateRoot<T> : IAggregateRoot where T : struct
{
    public T Id { get; protected set; }
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
