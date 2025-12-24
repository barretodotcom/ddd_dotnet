using StockService.Domain.Common.Repositories;
using StockService.Domain.Locals.Entities;
using StockService.Domain.Locals.ValueObjects;

namespace StockService.Domain.Locals.Repositories;

public interface ILocalRepository : IRepository<Local, LocalId>
{
    
}