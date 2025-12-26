using StockService.Application.Common.Paginate;
using StockService.Application.Stocks.DTOs;
using StockService.Application.Stocks.Queries;

namespace StockService.Application.Stocks.Services.GetStockServices;

public interface IGetStockService
{
    PagedResult<GetStockDto> Execute(GetStocksQuery query);
}