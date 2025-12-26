using StockService.Application.Stocks.Commands;
using StockService.Domain.Stocks.Entities;

namespace StockService.Application.Stocks.Services.CreateStockServices;

public interface ICreateStockService
{
    Stock Execute(CreateStockCommand command);
}