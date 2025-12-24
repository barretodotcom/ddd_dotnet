using Microsoft.EntityFrameworkCore;
using StockService.Domain.Locals.Entities;
using StockService.Domain.Locals.Repositories;
using StockService.Domain.Locals.ValueObjects;
using StockService.Infrastructure.Persistence.AppDbContexts;

namespace StockService.Infrastructure.Persistence.Repositories;

public class LocalRepository : Repository<Local, LocalId>, ILocalRepository
{
    public LocalRepository(AppDbContext context) : base(context)
    {
    }
}
