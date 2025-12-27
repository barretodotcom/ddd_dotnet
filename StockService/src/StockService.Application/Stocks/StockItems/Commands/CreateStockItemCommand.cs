namespace StockService.Application.Stocks.StockItems.Commands;

public class CreateStockItemCommand
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
}