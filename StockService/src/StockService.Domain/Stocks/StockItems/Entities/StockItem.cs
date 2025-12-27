using StockService.Domain.Products.Entities;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Stocks.Entities;
using StockService.Domain.Stocks.StockItems.ValueObjects;
using StockService.Domain.Stocks.ValueObjects;

namespace StockService.Domain.Stocks.StockItems.Entities;

public class StockItem
{
    public StockItemId Id { get; private set; }
    public ProductId ProductId { get; private set; }
    public StockId StockId { get; private set; }
    public decimal Quantity { get; private set; }

    public StockItem(StockItemId id, ProductId productId, StockId stockId, decimal quantity)
    {
        Id = id;
        ProductId = productId;
        StockId = stockId;
        Quantity = quantity;
    }

    public void AddQuantity(decimal quantity)
    {
        Quantity += quantity;
    }

}