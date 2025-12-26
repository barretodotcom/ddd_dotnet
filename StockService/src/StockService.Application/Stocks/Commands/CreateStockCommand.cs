namespace StockService.Application.Stocks.Commands;

public class CreateStockCommand
{
    public Guid LocalId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
}