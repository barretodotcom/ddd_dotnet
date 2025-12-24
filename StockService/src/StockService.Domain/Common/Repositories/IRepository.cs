namespace StockService.Domain.Common.Repositories;

public interface IRepository<TEntity, TId> where TEntity : class where TId : struct
{
    TEntity Get(TId id);
    void Delete(TEntity id);
    void Add(TEntity entity);
    void SaveChanges();
}