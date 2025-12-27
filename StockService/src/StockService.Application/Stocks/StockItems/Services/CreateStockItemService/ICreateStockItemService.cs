using StockService.Application.Stocks.StockItems.Commands;
using StockService.Domain.Stocks.ValueObjects;

namespace StockService.Application.Stocks.StockItems.Services.CreateStockItemService;

public interface ICreateStockItemService
{
    void Execute(StockId stockId, CreateStockItemCommand command);
}