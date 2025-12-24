using Microsoft.EntityFrameworkCore;
using StockService.Domain.Common.Repositories;

namespace StockService.Infrastructure.Persistence.Repositories;

public class Repository<TEntity, TId> : IRepository<TEntity, TId> 
    where TEntity: class 
    where TId : struct
{
    protected readonly DbSet<TEntity> DbSet;
    private readonly DbContext _dbContext;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    public TEntity Get(TId id)
    {
        return DbSet.Find(id)!;
    }

    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
}