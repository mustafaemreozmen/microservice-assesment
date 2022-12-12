using System.Linq.Expressions;
using Directory.Data.Entities;
using Directory.Data.Repositories.Interfaces;

namespace Directory.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
    protected DirectoryContext _directoryContext;

    public BaseRepository(DirectoryContext directoryContext)
    {
        _directoryContext ??= directoryContext;
    }
    public void Add(T entity)
    {
        _directoryContext.Set<T>().Add(entity);
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        return _directoryContext.Set<T>().FirstOrDefault(filter);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
    {
        return _directoryContext.Set<T>().Where(filter);
    }

    public void Remove(T entity)
    {
        _directoryContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        _directoryContext.Set<T>().Update(entity);
    }
}