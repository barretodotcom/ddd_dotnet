using StockService.Domain.Common.Exceptions;
using StockService.Domain.Locals.ValueObjects;
using StockService.Domain.Stocks.Entities;

namespace StockService.Domain.Locals.Entities;

public class Local
{
    public LocalId Id { get; private set; }
    public string Name { get; private set; }
    public List<Stock> Stocks { get; private set; } = new();
    
    private Local()
    {
    }

    public Local(LocalId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Local name cannot be null or empty.");

        Id = id;
        Name = name;
    }
}