namespace StockService.Domain.Common.Abstractions;

public class AggregateRoot<T> where T : struct
{
    public T Id { get; protected set; }
}
