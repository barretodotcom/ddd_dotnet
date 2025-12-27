using StockService.Application.Common.Result;
using StockService.Application.Stocks.StockItems.Commands;
using StockService.Domain.Products.Entities;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Stocks.Repositories;
using StockService.Domain.Stocks.StockItems.Entities;
using StockService.Domain.Stocks.StockItems.ValueObjects;
using StockService.Domain.Stocks.ValueObjects;

namespace StockService.Application.Stocks.StockItems.Services.CreateStockItemService;

public class CreateStockItemService : ICreateStockItemService
{
    private readonly IResultService _resultService;
    private readonly IStockRepository _stockRepository;

    public CreateStockItemService(IStockRepository stockRepository, IResultService resultService)
    {
        _resultService = resultService;
        _stockRepository = stockRepository;
    }

    public void Execute(StockId stockId, CreateStockItemCommand command)
    {
        var stock = _stockRepository.Get(stockId);

        if (command.Quantity < 0)
        {
            _resultService.AddMessage("Quantity cannot be negative");
            return;
        }

        var stockItemId = new StockItemId(Guid.NewGuid());

        var productId = new ProductId(command.ProductId);

        stock.AddItem(new StockItem(stockItemId, productId, stock.Id, command.Quantity));
        
        _stockRepository.Update(stock);
        _stockRepository.SaveChanges();
    }
}