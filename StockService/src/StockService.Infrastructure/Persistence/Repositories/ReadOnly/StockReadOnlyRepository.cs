using StockService.Application.Common.Paginate;
using StockService.Application.Stocks.DTOs;
using StockService.Application.Stocks.Queries;
using StockService.Application.Stocks.ReadOnlyRepositories;
using StockService.Domain.Locals.ValueObjects;
using StockService.Infrastructure.Persistence.AppDbContexts;
using StockService.Infrastructure.Persistence.Extensions;

namespace StockService.Infrastructure.Persistence.Repositories.ReadOnly;

public class StockReadOnlyRepository : IStockReadOnlyRepository
{
    private readonly AppDbContext _dbContext;

    public StockReadOnlyRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public PagedResult<GetStockDto> GetPaginated(GetStocksQuery query)
    {
        var queryable = (
            from stock in _dbContext.Stocks
                .WhereIf(query.LocalId.HasValue, l => l.LocalId == new LocalId(query.LocalId!.Value))
            join local in _dbContext.Locals
                on stock.LocalId equals local.Id
            select new GetStockDto()
            {
                Id = stock.Id.Value,
                LocalId = stock.LocalId.Value,
                LocalName = local.Name,
                Name = "",
            }
        );

        var count = queryable.Count();

        var items = queryable
            .Skip(query.PageNumber * query.PageSize)
            .Take(query.PageSize)
            .ToList();

        return new PagedResult<GetStockDto>()
        {
            TotalCount = count,
            Items = items,
            PageCount = items.Count,
        };
    }
}