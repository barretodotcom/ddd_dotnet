using Microsoft.EntityFrameworkCore.Diagnostics;
using NNotificator.Abstractions;
using StockService.Domain.Common.Abstractions;

namespace StockService.Infrastructure.Persistence.Interceptor;

public class DomainEventInterceptor : SaveChangesInterceptor
{
    private readonly IEventPublisher _eventPublisher;

    public DomainEventInterceptor(IEventPublisher eventPublisher)
    {
        _eventPublisher = eventPublisher;
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        var cancellationToken = new CancellationToken();
        PublishDomainEvents(eventData, cancellationToken).ConfigureAwait(true).GetAwaiter().GetResult();
        return base.SavedChanges(eventData, result);
    }

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await PublishDomainEvents(eventData, cancellationToken);
        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private async Task PublishDomainEvents(SaveChangesCompletedEventData eventData, CancellationToken cancellationToken)
    {
        if (eventData.Context == null) return;

        var domainEvents = eventData.Context.ChangeTracker
            .Entries<IAggregateRoot>()
            .Select(l => l.Entity)
            .SelectMany(l => l.DomainEvents)
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _eventPublisher.PublishAsync(domainEvent, cancellationToken);
        }

        var entities = eventData.Context.ChangeTracker
            .Entries<IAggregateRoot>()
            .Select(l => l.Entity);

        foreach (var entity in entities)
        {
            entity.ClearDomainEvents();
        }
    }
}