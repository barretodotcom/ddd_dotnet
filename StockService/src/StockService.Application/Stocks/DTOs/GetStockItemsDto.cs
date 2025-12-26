namespace StockService.Application.Stocks.DTOs;

public class GetStockItemsDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
}