using StockService.Application.Stocks.Commands;
using StockService.Domain.Locals.ValueObjects;
using StockService.Domain.Products.ValueObjects;
using StockService.Domain.Stocks.Entities;
using StockService.Domain.Stocks.Repositories;
using StockService.Domain.Stocks.ValueObjects;

namespace StockService.Application.Stocks.Services.CreateStockServices;

public class CreateStockService : ICreateStockService
{
    private readonly IStockRepository _stockRepository;

    public CreateStockService(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    public Stock Execute(CreateStockCommand command)
    {
        var localId = new LocalId(command.LocalId);
        var productId = new ProductId(command.ProductId);

        var stock = new Stock(new StockId(Guid.NewGuid()), localId, productId);
        stock.AddQuantity(command.Quantity);
        _stockRepository.Add(stock);

        _stockRepository.SaveChanges();

        return stock;
    }
}