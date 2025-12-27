using StockService.Domain.Common.Abstractions;
using StockService.Domain.Common.Exceptions;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Locals.ValueObjects;
using StockService.Domain.Products.Entities;
using StockService.Domain.Locals.Entities;
using StockService.Domain.Stocks.StockItems.Entities;
using StockService.Domain.Stocks.ValueObjects;

namespace StockService.Domain.Stocks.Entities;

public class Stock : AggregateRoot<StockId>
{
    public LocalId LocalId { get; private set; }
    public ProductId ProductId { get; private set; }
    public decimal Quantity { get; private set; }
    public decimal ReservedQuantity { get; private set; }
    public Local Local { get; private set; }
    public Product Product { get; private set; }
    public List<StockItem> StockItems { get; private set; } = new();

    public Stock(StockId id, LocalId localId, ProductId productId)
    {
        Id = id;
        LocalId = localId;
        ProductId = productId;
    }
    public Stock(StockId id, LocalId localId, ProductId productId, decimal quantity, decimal reservedQuantity)
    {
        Id = id;
        LocalId = localId;
        ProductId = productId;
        Quantity = quantity;
        ReservedQuantity = reservedQuantity;
    }

    public void AddQuantity(decimal quantity)
    {
        Quantity += quantity;
    }

    public void AddItem(StockItem stockItem)
    {
        StockItems.Add(stockItem);
    }

    public void ReserveQuantity(decimal amount)
    {
        if (amount <= 0)
            throw new DomainException("Amount to reserve must be greater than zero.");

        if (ReservedQuantity + amount > Quantity)
            throw new DomainException("Insufficient stock available to reserve the requested amount.");

        ReservedQuantity += amount;
    }
}