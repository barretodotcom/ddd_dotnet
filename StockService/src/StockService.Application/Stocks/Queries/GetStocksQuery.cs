using StockService.Application.Common.Paginate;

namespace StockService.Application.Stocks.Queries;

public class GetStocksQuery : PagedQuery
{
    public Guid? LocalId { get; set; }
}