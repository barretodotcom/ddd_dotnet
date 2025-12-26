using StockService.Application.Common.Paginate;
using StockService.Application.Stocks.DTOs;
using StockService.Application.Stocks.Queries;

namespace StockService.Application.Stocks.ReadOnlyRepositories;

public interface IStockReadOnlyRepository
{
    public PagedResult<GetStockDto> GetPaginated(GetStocksQuery query);
}