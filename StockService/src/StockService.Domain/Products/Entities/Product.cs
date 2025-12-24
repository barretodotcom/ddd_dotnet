using StockService.Domain.Common.Exceptions;

namespace StockService.Domain.Products.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Product() { }

    public Product(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Product name cannot be null or empty.");
        
        Id = id;
        Name = name;
    }

}