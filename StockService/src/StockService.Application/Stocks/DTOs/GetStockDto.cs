namespace StockService.Application.Stocks.DTOs;

public class GetStockDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid LocalId { get; set; }
    public string LocalName { get; set; }
}