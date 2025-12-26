using StockService.Domain.Common.Abstractions;
using StockService.Domain.Common.Exceptions;
using StockService.Domain.Products.Events;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Stocks.Entities;

namespace StockService.Domain.Products.Entities;

public class Product : AggregateRoot<ProductId>
{
    public ProductId Id { get; private set; }
    public string Name { get; private set; }
    public List<Stock> Stocks { get; private set; } = new();

    private Product()
    {
    }

    public Product(ProductId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Product name cannot be null or empty.");

        Id = id;
        Name = name;
        
        AddDomainEvent(new ProductCreatedEvent(id));
    }
}