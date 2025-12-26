using StockService.Application.Common.Paginate;
using StockService.Application.Stocks.DTOs;
using StockService.Application.Stocks.Queries;
using StockService.Application.Stocks.ReadOnlyRepositories;

namespace StockService.Application.Stocks.Services.GetStockServices;

public class GetStockService : IGetStockService
{
    private readonly IStockReadOnlyRepository _repository;

    public GetStockService(IStockReadOnlyRepository repository)
    {
        _repository = repository;
    }
    
    public PagedResult<GetStockDto> Execute(GetStocksQuery query)
    {
        return _repository.GetPaginated(query);
    }
}